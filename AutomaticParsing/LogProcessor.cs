using ParseTHSMsg.AutomaticParsing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseTHSMsg
{
    public static class Constants
    {
        public const string DateTimeMask = @"(?<Year>(?:\d{4}))-(?<Month>\d{2})-(?<Day>\d{2})\s\d{2}:\d{2}:\d{2},\d{6}";

        // public const string DtRegCommon2 = @"(?<Day>\d{2})\s(?<Month>\D{3})\s(?<Year>\d{4})\s(?<Time>\d{2}:\d{2}:\d{2},\d{3}\s)";

        public const string CallIdMask = @"Call-ID:\s";

        public const string DateTimeFormat = @"yyyy-MM-dd HH:mm:ss,ffffff";
    }

    public class LogProcessor
    {
        public LogProcessor()
        { }

        public string ProcessLogFile(string directory, LogProcessorSettings settings, Action<Message> ProcessMsgAction)
        {
            string logFileName = settings.LogFile.LogFileName;
            SourceType logType = settings.LogFile.SourceType;
            
            var lines = File.ReadLines(logFileName);                
                
            StringBuilder sbFileResult = ProcessSourceText(lines, settings, ProcessMsgAction);

            if (settings.CreateSeparateMessageLists)
            {
                string filePath = Path.Combine(directory, logType + ".MESSAGES");

                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, sbFileResult.ToString());
                }
                else
                {
                    TextWriter tw = new StreamWriter(filePath, true);
                    tw.WriteLine(sbFileResult);
                    tw.Close();
                }
                return filePath;
            }
            else
                return null;                       
        }

        public StringBuilder ProcessSourceText(
            IEnumerable<string> lines, LogProcessorSettings processorSettings, Action<Message> ProcessMsgAction)
        {
            Console.WriteLine("IN ProcessSourceText");
            var sbResult = new StringBuilder();

            var matcher = processorSettings.LogFile.MatcherSettings;
            var uiFilters = processorSettings.UIFS;

            var regLine = new Regex(matcher.MessageMask);
            
            var regDateStamp = new Regex(matcher.DateTimeMask ?? Constants.DateTimeMask);

            var regCallId = uiFilters.CallIdFilterText != null ? new Regex(uiFilters.CallIdFilterText) : null;

            var regHeartbeat = uiFilters.IncludeHeartbeat ? null : new Regex("HEARTBEAT");

            var regSIP200OK = uiFilters.IncludeSIP200 ? null : new Regex(@"SIP/2.0\s200\sOK");

            var isFilterByTimeFrom = uiFilters.DateTimeFrom.HasValue;
            var dateTimeFrom = uiFilters.DateTimeFrom.HasValue ? uiFilters.DateTimeFrom.Value : DateTime.MinValue ;

            var isFilterByTimeTo = uiFilters.DateTimeTo.HasValue;
            var dateTimeTo = uiFilters.DateTimeTo.HasValue ? uiFilters.DateTimeTo.Value : DateTime.MinValue;

            var lineCount = 0;

            Regex regRTSMMessages = null;
            if (uiFilters.FilterRTSMMessages)
            {
                regRTSMMessages = new Regex("telhdl:onCall(Created|Modified|Removed)");
            }

            try
            {
                using (var enumerator = (lines).GetEnumerator())
                {
                    var noCheckNext = false;
                    var eof = false;
                    while (!eof && (noCheckNext || enumerator.MoveNext()))
                    {
                        if(!noCheckNext)                        
                            lineCount++;

                        noCheckNext = false;

                        var line = (string)enumerator.Current;
                        var sbMsg = new StringBuilder();
                        var isMsgLineMatch = noCheckNext || regLine.IsMatch(line);

                        var mDate = regDateStamp.Match(line);           

                        if ((isFilterByTimeFrom || isFilterByTimeTo) && isMsgLineMatch && mDate.Success) // This is timestamp string.  Need to filter by "Time From"
                        {                            
                            DateTime dtParsed = DateTime.MinValue;
                            string sDateTimeParsed = mDate.Value;
                            CultureInfo provider = CultureInfo.InvariantCulture;
                            string sFormat = processorSettings.LogFile.MatcherSettings.DateTimeFormat ?? Constants.DateTimeFormat;

                            if(DateTime.TryParseExact(sDateTimeParsed, sFormat, CultureInfo.InvariantCulture,
                                DateTimeStyles.AllowWhiteSpaces & DateTimeStyles.AssumeLocal, out dtParsed))
                            {
                                if (isFilterByTimeFrom && dateTimeFrom > dtParsed
                                    || isFilterByTimeTo && dateTimeTo < dtParsed)
                                {
                                    noCheckNext = false;
                                    continue;
                                }
                            }                            
                        }

                        if (noCheckNext || mDate.Success && isMsgLineMatch)
                        {
                            noCheckNext = false;

                            sbMsg.Append(line);
                            var isFilterByCallId = regCallId != null; 

                            var isCallIdMatch = !isFilterByCallId;
                            var hasPresenceLine = false;

                            var doInnerCycle = true;                            
                            do
                            {
                                eof = !enumerator.MoveNext();
                                if (!eof)
                                {
                                    lineCount++;
                                    line = (string)enumerator.Current;
                                    if (isFilterByCallId && !isCallIdMatch)
                                    {
                                        isCallIdMatch = regCallId.IsMatch(line);
                                    }
                                    if (line.Contains("<presence") || line.Contains("<presence_update") || line.Contains("<wcc-notify"))
                                        hasPresenceLine = true;

                                    if (!regDateStamp.IsMatch(line))
                                        sbMsg.Append(Environment.NewLine + line);
                                    else
                                    {
                                        noCheckNext = regDateStamp.IsMatch(line) && regLine.IsMatch(line);
                                        doInnerCycle = false;
                                    }
                                }
                            } while (doInnerCycle && !eof);                               

                            //check filters
                            //callId filter
                            if (isFilterByCallId && !isCallIdMatch)
                                continue;

                            //"include presence" filter                            
                            if (!uiFilters.IncludePresenceMsgs)
                            {
                                if (hasPresenceLine)
                                    continue;
                            }

                            string txtReceived = null;
                            string txtSent = null;

                            var msg = sbMsg.ToString();

                            if (regSIP200OK != null)
                            {
                                if (regSIP200OK.IsMatch(msg))
                                    continue;
                            }

                            if (regHeartbeat != null)
                            {
                                if (regHeartbeat.IsMatch(msg))
                                    continue;
                            }

                            // RTSM filter - allow only telhdl:onCallXxxxxxx msgs
                            if (uiFilters.FilterRTSMMessages && regRTSMMessages != null && !regRTSMMessages.IsMatch(msg))
                            {
                                continue;
                            }

                            if(uiFilters.ExcludeThsMonitorMessages && msg.Contains("<ths_monitor>"))
                            {
                                continue;
                            }
                            

                            var normalizedMsg = msg.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                            var message = CreateMessageFromStr(msg, processorSettings.LogFile.SourceType, processorSettings.LogFile.MatcherSettings);
                            ProcessMsgAction(message);

                            sbResult.Append(string.Concat(txtReceived, txtSent, msg, Environment.NewLine));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Console.WriteLine("Processed {0} lines", lineCount);
            return sbResult;
        }

        private static Message CreateMessageFromStr(string msg, SourceType SourceType, MessageMatcherSettings s)
        {
            var msgLines = msg.Split('\n');
            if (msgLines.Length == 0)
                return null;

            var regInc = s.IncomingMask != null ? new Regex(s.IncomingMask) : null;

            var regOutg = s.OutgoingMask != null ? new Regex(s.OutgoingMask) : null;

            var regDateStamp = new Regex(s.DateTimeMask ?? Constants.DateTimeMask);

            var message = new Message();
            message.SourceType = SourceType;
            var line = msgLines[0];

            if (regInc.IsMatch(line))
                message.isIncoming = true;

            message.DirectionText = message.isIncoming ? "➘" : "➚";

            var sTime = regDateStamp.Match(line).Value;

            DateTime dt = DateTime.MinValue;
            DateTime.TryParseExact(sTime,
                                   s.DateTimeFormat ?? Constants.DateTimeFormat,
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.AllowWhiteSpaces & DateTimeStyles.AssumeLocal,
                                   
                                   out dt);
            message.Timestamp = dt;
            message.TimestampStr = sTime;

            int captionIx = 0;

            if (msgLines.Length > 1)
            {
                captionIx =
                    SourceType == SourceType.Tns
                    && msgLines.Length > 1
                    && msgLines[1].Contains("header:") ? 2 : 1;
            }
            message.Caption = msgLines[captionIx];

            // Remove timestamp from message body
            var text = msg;
            var timeStart = text.IndexOf(sTime);
            if (text.IndexOf(sTime)!=-1)
            {
                text = text.Remove(timeStart, sTime.Length);
            }

            message.Text = text;
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            message.PreviewText = string.Join(Environment.NewLine, lines.Take(10));
            message.FullText = string.Join(Environment.NewLine, lines.Skip(10));
            return message;
        }

    }
}

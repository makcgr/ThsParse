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
        public const string DtRegCommon = @"(?<Year>(?:\d{4}))-(?<Month>\d{2})-(?<Day>\d{2})\s\d{2}:\d{2}:\d{2},\d{6}\s";

        public const string DtRegCommon2 = @"(?<Day>\d{2})\s(?<Month>\D{3})\s(?<Year>\d{4})\s(?<Time>\d{2}:\d{2}:\d{2},\d{3}\s)";

        public const string CallIdRegCommon = @"Call-ID:\s";
    }

    public class LogProcessor
    {
        public LogProcessor()
        { }

        public static LogProcessorSettings CreateSettingsFromACSLogFile(ACSLogFile logFile)
        {
            return new LogProcessorSettings()
            {
                LogFile = logFile,
                MsgRegexText = logFile.LogInfo.MessageMask,
                DateRegexText = Constants.DtRegCommon,
                IncomingRegexText = logFile.LogInfo.IncomingMask,
                OutgoingRegexText = logFile.LogInfo.OutgoingMask
            };
        }

        public string ProcessLogFile(string directory, LogProcessorSettings settings, Action<Message> ProcessMsgAction)
        {
            string logFileName = settings.LogFile.LogFileName;
            SourceType logType = settings.LogFile.SourceType;

            try
            {
                var lines = File.ReadLines(logFileName);                
                
                StringBuilder sbFileResult = ProcessSourceText(lines, settings, ProcessMsgAction);

                string filePath = Path.Combine(directory, logType + ".SIPCC");

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
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("An error occured when processing file{0}{1}{2}{3}", logFileName, Environment.NewLine, "Error:", ex)
                    );
                
            }
            return null;
        }

        public StringBuilder ProcessSourceText(
            IEnumerable<string> lines, LogProcessorSettings s, Action<Message> ProcessMsgAction)
        {
            Console.WriteLine("IN ProcessSourceText");
            var sbResult = new StringBuilder();

            var regLine = new Regex(s.MsgRegexText);
            
            var regDateStamp = new Regex(s.DateRegexText);

            var regCallId = s.CallIdFilterText != null ? new Regex(s.CallIdFilterText) : null;

            var regHeartbeat = s.IncludeHeartbeat ? null : new Regex("HEARTBEAT");

            var regSIP200OK = s.IncludeSIP200 ? null : new Regex("SIP/2.0 200 OK");

            var defTime = DateTime.Now.Date;

            var lineCount = 0;
            try
            {

                using (var enumerator = (lines).GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        lineCount++;
                        var line = (string)enumerator.Current;
                        var sbMsg = new StringBuilder();                        

                        if (regDateStamp.IsMatch(line) && regLine.IsMatch(line))
                        {
                            sbMsg.Append(line);

                            var isFilterByCallId = regCallId != null; 

                            var isCallIdMatch = !isFilterByCallId;
                            var hasPresenceLine = false;

                            var checkNextLine = true;
                            bool eof = false;
                            while (checkNextLine && !eof)
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
                                    if (line.Contains("<presence>") || line.Contains("<presence_update>"))
                                        hasPresenceLine = true;

                                    if (!regDateStamp.IsMatch(line))
                                        sbMsg.Append(Environment.NewLine + line);
                                    else
                                        checkNextLine = false;
                                }                                
                            }
                            if (eof)
                                break;

                            //check filters
                            //callId filter
                            if (isFilterByCallId && !isCallIdMatch)
                                continue;

                            //"include presence" filter                            
                            if (s.IncludePresenceMsgs)
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

                            var normalizedMsg = msg.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                            var message = CreateMessageFromStr(msg, s);
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

        private static Message CreateMessageFromStr(string msg, LogProcessorSettings s)
        {
            var msgLines = msg.Split('\n');
            if (msgLines.Length == 0)
                return null;

            var regInc = s.IncomingRegexText != null ? new Regex(s.IncomingRegexText) : null;

            var regOutg = s.OutgoingRegexText != null ? new Regex(s.OutgoingRegexText) : null;

            var regDateStamp = new Regex(s.DateRegexText);


            var message = new Message();
            message.SourceType = s.LogFile.SourceType;
            var line = msgLines[0];

            if (regInc.IsMatch(line))
                message.isIncoming = true;

            message.DirectionText = message.isIncoming ? "➘" : "➚";

            var sTime = regDateStamp.Match(line).Value;

            DateTime dt = DateTime.MinValue;
            DateTime.TryParseExact(sTime,
                                   "yyyy-MM-dd HH:mm:ss,ffffff",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.AllowWhiteSpaces,
                                   out dt);
            message.Timestamp = dt;
            message.TimestampStr = sTime;

            int captionIx = 0;

            if (msgLines.Length > 1)
            {
                captionIx =
                    s.LogFile.SourceType == SourceType.Tns
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


    public class LogProcessorSettings
    {
        public LogProcessorSettings() { }
        
        public ACSLogFile LogFile { get; set; }
        public string MsgRegexText { get; set; }
        public string DateRegexText { get; set; }
        public string CallIdFilterText { get; set; }
        public string IncomingRegexText { get; set; }
        public string OutgoingRegexText { get; set; }
        public bool IncludeHeartbeat { get; set; }
        public bool IncludeSIP200 { get; set; }
        public bool IncludePresenceMsgs { get; set; }
    }
}

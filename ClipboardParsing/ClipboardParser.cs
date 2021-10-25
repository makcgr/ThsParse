using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParseTHSMsg
{
    public static class ClipboardParser
    {
        public static StringBuilder ParseMessages(StringBuilder sbSource, string sRegexLine, string sRegexDate, bool isFilterByCallId, 
            string sCallIdFilter, bool bIncludeHeartbeat, bool bIncludeSIP200, bool bIncludePresenceMsgs, bool bDecorateWithDirectionArrows, 
            string sArrowDecorationIn, string sArrowDecorationOut, string strDirectionInRegex, string strDirectionOutRegex)
        {
            var sb = sbSource;
            var sbResult = new StringBuilder();

            var regLine = new Regex(sRegexLine);
            var regDateStamp = new Regex(sRegexDate);
            var regCallId = isFilterByCallId ? new Regex(sCallIdFilter) : null;
            var regHeartbeat = bIncludeHeartbeat ? null : new Regex("HEARTBEAT");
            var regSIP200OK = bIncludeSIP200 ? null : new Regex("SIP/2.0 200 OK");

            Regex regReceived = bDecorateWithDirectionArrows ? null : new Regex(strDirectionInRegex);
            Regex regSent = bDecorateWithDirectionArrows ? null : new Regex(strDirectionOutRegex);

            var count = sb.ToString().Lines();

            using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()))))
            {
                for (int i = 0; i < count; i++)
                {
                    var sbMsg = new StringBuilder();

                    var s = sr.ReadLine() ?? "";

                    if (regLine.IsMatch(s))
                    {
                        sbMsg.Append(s);

                        var isCallIdMatch = !isFilterByCallId;
                        var hasPresenceLine = false;

                        var checkNextLine = true;
                        while (checkNextLine && i < count)
                        {
                            s = sr.ReadLine() ?? ""; i++;
                            if (isFilterByCallId && !isCallIdMatch)
                            {
                                isCallIdMatch = regCallId.IsMatch(s);
                            }
                            if (s.Contains("<presence>") || s.Contains("<presence_update>"))
                                hasPresenceLine = true;

                            if (!regDateStamp.IsMatch(s))
                                sbMsg.Append(Environment.NewLine + s);
                            else
                                checkNextLine = false;
                        }

                        //check user filters

                        //callId filter
                        if (isFilterByCallId && !isCallIdMatch)
                            continue;

                        //"include presence" filter                            
                        if (!bIncludePresenceMsgs)
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

                        if (bDecorateWithDirectionArrows)
                        {
                            txtReceived = regReceived != null && regReceived.IsMatch(msg)
                                        ? sArrowDecorationIn + Environment.NewLine
                                        : null;
                            txtSent = regSent != null && regSent.IsMatch(msg)
                                ? sArrowDecorationOut + Environment.NewLine
                                : null;
                        }

                        sbResult.Append(string.Concat(txtReceived, txtSent, msg, Environment.NewLine));

                    }
                }
            }
            return sbResult;
        }

    }
}

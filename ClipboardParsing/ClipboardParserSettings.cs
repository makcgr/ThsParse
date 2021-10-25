using System.Data;

namespace ParseTHSMsg.ClipboardParsing
{
    public static class ClipboardParserSettings
    {
        static string sDtRegCommon = @"(?<Year>(?:\d{4}))-(?<Month>\d{2})-(?<Day>\d{2})\s\d{2}:\d{2}:\d{2},\d{6}\s";

        static string sDtRegCommon2 = @"(?<Day>\d{2})\s(?<Month>\D{3})\s(?<Year>\d{4})\s(?<Time>\d{2}:\d{2}:\d{2},\d{3}\s)";

        static string sCallIdRegCommon = @"Call-ID:\s";

        public static void FillData(DataTable tTemplates)
        {
            DataTable dt = tTemplates;

            dt.LoadDataRow(new object[] { 1, @"(Sent\smessage\sto|Forking\sinter_ths_sip|Received\smessage\sfrom)", "For THS log messages", @"Received\smessage", @"Sent\smessage|Forking\sinter_ths_sip", false, sDtRegCommon, sCallIdRegCommon }, true);
            dt.LoadDataRow(new object[] { 2, @"(SENDING\sMESSAGE\sTO\s|RECEIVED\sMESSAGE\sFROM\s)", "For buddyconsole log messages", @"RECEIVED\sMESSAGE", @"SENDING\sMESSAGE", false, sDtRegCommon, sCallIdRegCommon }, true);

            dt.LoadDataRow(new object[] { 3, @"(process:\s=====|send_message:)", "For TNS", @"process:\s=====", @"send_message:", false, sDtRegCommon, sCallIdRegCommon }, true);
            dt.LoadDataRow(new object[] { 4, @"(Sending\s|Received\s)", "For tp240dvr", @"Sending\s", @"Received\s", false, sDtRegCommon, sCallIdRegCommon }, true);

            dt.LoadDataRow(new object[] { 5, @"(Sending\smessage\sto\sXMPP\sDomain|Parsed\sXMPP\smessage)", "For XMPP messages", @"Parsed\sXMPP\smessage", @"Sending\smessage\sto\sXMPP\sDomain", false, sDtRegCommon, sCallIdRegCommon }, true);

            dt.LoadDataRow(new object[] { 6, @"onReceiveEvent\sRTSMCallEvent", "For chameleon RTSMCallEvent messages", @"", @"", true, sDtRegCommon2, @"callRef:\s" }, true);
            dt.LoadDataRow(new object[] { 7, @"ServerInterface.UpdateCall", "OTC_PC log - ServerInterface.UpdateCall", @"", @"", true, sDtRegCommon2, @"" }, true);
        }
    }
}

using System;

namespace ParseTHSMsg
{
    [Serializable]
    public class MessageMatcherSettings
    {
        public string DateTimeMask;
        public string DateTimeFormat;
        public string MessageMask;
        public string IncomingMask;
        public string OutgoingMask;
        public string LogFileNameMask;

        public MessageMatcherSettings() { }

        public MessageMatcherSettings(string fileNameMask, string messageMask, string incomingMask, string outgoingMask)
        {
            LogFileNameMask = fileNameMask;
            MessageMask = messageMask;
            IncomingMask = incomingMask;
            OutgoingMask = outgoingMask;
        }
    }
}

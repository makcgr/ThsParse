using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseTHSMsg
{
    public enum SourceType
    {
        Unknown,
        Buddy,
        Ths,
        Tns,
        Tpdrv
    }

    public class ACSLogFileTypeInfo
    {
        public string MessageMask;
        public string IncomingMask;
        public string OutgoingMask;
        public string LogFileNameMask;
        public Regex LogFileNameRgx;
        public Regex MessageMaskRgx;
        public Regex IncomingMaskRgx;
        public Regex OutgoingMaskRgx;

        public ACSLogFileTypeInfo(string fileNameMask, string messageMask) : this(fileNameMask,messageMask,null,null)
        {}

        public ACSLogFileTypeInfo(string fileNameMask, string messageMask, string incomingMask, string outgoingMask)
        {
            LogFileNameMask = fileNameMask;
            LogFileNameRgx = new Regex(fileNameMask);
            MessageMask = messageMask;
            MessageMaskRgx = new Regex(messageMask);
            IncomingMask = incomingMask;
            if(incomingMask != null)
                IncomingMaskRgx = new Regex(incomingMask);
            OutgoingMask = outgoingMask;
            if(outgoingMask != null)
                OutgoingMaskRgx = new Regex(outgoingMask);
        }
    }

    public class ACSLogFile
    {
        public string LogFileName;
        public SourceType SourceType;
        public ACSLogFileTypeInfo LogInfo;
    }
}

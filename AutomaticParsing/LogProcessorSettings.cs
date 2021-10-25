using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTHSMsg.AutomaticParsing
{
    public class LogProcessorSettings
    {
        public LogProcessorSettings() { }

        public ACSLogFile LogFile { get; set; }
        public UIFilterSettings UIFS { get; set; }
        public bool CreateSeparateMessageLists { get; set; }
    }
}

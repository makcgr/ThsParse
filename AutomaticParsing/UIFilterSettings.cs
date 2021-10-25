using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTHSMsg.AutomaticParsing
{
    public class UIFilterSettings
    {
        public bool IncludeHeartbeat { get; set; }
        public bool IncludeSIP200 { get; set; }
        public bool IncludePresenceMsgs { get; set; }
        public bool FilterRTSMMessages { get; set; }
        public bool ExcludeThsMonitorMessages { get; set; }
        public DateTime? DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
        public string CallIdFilterText { get; set; }
    }
}

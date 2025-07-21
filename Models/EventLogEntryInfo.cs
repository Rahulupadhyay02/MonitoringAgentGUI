using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class EventLogEntryInfo
    {
        public string LogName { get; set; }
        public string Source { get; set; }
        public string EntryType { get; set; }
        public string Message { get; set; }
        public DateTime TimeGenerated { get; set; }
    }
}

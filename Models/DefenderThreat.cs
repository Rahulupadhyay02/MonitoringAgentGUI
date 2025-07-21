using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonitoringAgent.Models
{
    public class DefenderThreat
    {
        public string ThreatName { get; set; }
        public string Severity { get; set; }
        public string ActionTaken { get; set; }
        public DateTime? DetectionTime { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string Error { get; set; }
    }
}

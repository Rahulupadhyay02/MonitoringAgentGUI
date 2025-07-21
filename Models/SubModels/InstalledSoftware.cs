using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class InstalledSoftware
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Publisher { get; set; }

        public string Status { get; set; }              // "Running" or "Idle"
        public DateTime? LastUsedTime { get; set; }
    }
}

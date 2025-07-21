using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class SystemUptimeInfo
    {
        public DateTime? LastBootTime { get; set; }
        public double UptimeSeconds { get; set; }
        public string UptimeReadable { get; set; }
        public string Error { get; set; }
    }
}

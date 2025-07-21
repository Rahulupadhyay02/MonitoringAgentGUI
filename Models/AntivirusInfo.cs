using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class AntivirusInfo
    {
        public string ProductName { get; set; }
        public string ProductState { get; set; }
        public bool RealTimeProtectionEnabled { get; set; }
        public DateTime? LastScanDate { get; set; }
        public string Error { get; set; }
    }
}

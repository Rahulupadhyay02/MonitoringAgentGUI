using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class PortInfo
    {
        public int Port { get; set; }
        public string Protocol { get; set; }
        public string ProcessName { get; set; }
        public int ProcessId { get; set; }
        public string State { get; set; }
        public string Error { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class SecurityEvent
    {
        public int EventID { get; set; }
        public string ProviderName { get; set; }
        public string Message { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string Error { get; set; }
    }
}


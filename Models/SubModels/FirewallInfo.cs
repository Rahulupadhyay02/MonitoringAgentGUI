using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class FirewallInfo
    {
        public bool IsFirewallEnabled { get; set; }
        public bool DomainEnabled { get; set; }
        public bool PrivateEnabled { get; set; }
        public bool PublicEnabled { get; set; }

        public int? DefaultInboundAction { get; set; }
        public int? DefaultOutboundAction { get; set; }
        public int RuleCount { get; set; }

        public string Error { get; set; }
    }
}

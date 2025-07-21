using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MonitoringAgent.Models
{
    public class FirewallProfile
    {
        public string Name { get; set; }
        public JsonElement Enabled { get; set; }
        public int? DefaultInboundAction { get; set; }
        public int? DefaultOutboundAction { get; set; }

        public bool IsEnabled =>
            Enabled.ValueKind == JsonValueKind.True ||
            (Enabled.ValueKind == JsonValueKind.Number && Enabled.GetInt32() != 0);
    }
}

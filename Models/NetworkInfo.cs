using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class NetworkInfo
    {
        public List<NetworkAdapter> Adapters { get; set; } = new();
        public string Error { get; set; }
    }

    public class NetworkAdapter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IPv4Address { get; set; }
        public string SubnetMask { get; set; }
        public string Gateway { get; set; }
        public string DNS { get; set; }
        public bool IsUp { get; set; }
    }
}


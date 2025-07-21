using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonitoringAgent.Models
{
    public class DeviceInfo
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SystemType { get; set; }
        public string SerialNumber { get; set; }
        public string BIOSVersion { get; set; }
        public string OSName { get; set; }
        public string OSArchitecture { get; set; }
        public string OSVersion { get; set; }
        public string Motherboard { get; set; }

        public IPConfiguration IPConfig { get; set; }

        public string Error { get; set; }
    }

    public class IPConfiguration
    {
        public string Hostname { get; set; }
        public string IPv4Address { get; set; }
        public string SubnetMask { get; set; }
        public string DefaultGateway { get; set; }
        public List<string> DnsServers { get; set; }
    }
}

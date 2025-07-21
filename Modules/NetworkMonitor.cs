using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringAgent.Models;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Management;

namespace MonitoringAgent.Modules
{
    public static class NetworkMonitor
    {
        public static NetworkInfo GetNetworkInfo()
        {
            try
            {
                var networkInfo = new NetworkInfo();
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE");

                foreach (ManagementObject obj in searcher.Get())
                {
                    var adapter = new NetworkAdapter
                    {
                        Name = obj["Caption"]?.ToString(),
                        Description = obj["Description"]?.ToString(),
                        IPv4Address = (obj["IPAddress"] as string[])?.FirstOrDefault(ip => ip.Contains(".")),
                        SubnetMask = (obj["IPSubnet"] as string[])?.FirstOrDefault(),
                        Gateway = (obj["DefaultIPGateway"] as string[])?.FirstOrDefault(),
                        DNS = (obj["DNSServerSearchOrder"] as string[]) != null
                              ? string.Join(", ", (string[])obj["DNSServerSearchOrder"]) : null,
                        IsUp = true
                    };

                    networkInfo.Adapters.Add(adapter);
                }

                return networkInfo;
            }
            catch (Exception ex)
            {
                return new NetworkInfo { Error = $"[Exception] {ex.Message}" };
            }
        }
    }
}


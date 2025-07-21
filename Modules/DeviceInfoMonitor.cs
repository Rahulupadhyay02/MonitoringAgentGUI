using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class DeviceInfoMonitor
    {
        public static DeviceInfo GetDeviceInfo()
        {
            var info = new DeviceInfo();
            info.IPConfig = new IPConfiguration
            {
                DnsServers = new List<string>()
            };

            try
            {
                // Basic Computer Info
                using (var csSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"))
                {
                    foreach (var obj in csSearcher.Get())
                    {
                        info.Manufacturer = obj["Manufacturer"]?.ToString();
                        info.Model = obj["Model"]?.ToString();
                        info.SystemType = obj["SystemType"]?.ToString();
                    }
                }

                // BIOS Info
                using (var biosSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))
                {
                    foreach (var obj in biosSearcher.Get())
                    {
                        info.SerialNumber = obj["SerialNumber"]?.ToString();
                        if (obj["BIOSVersion"] is string[] versions)
                        {
                            info.BIOSVersion = string.Join(", ", versions);
                        }
                    }
                }

                // OS Info
                using (var osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    foreach (var obj in osSearcher.Get())
                    {
                        info.OSName = obj["Caption"]?.ToString();
                        info.OSArchitecture = obj["OSArchitecture"]?.ToString();
                        info.OSVersion = obj["Version"]?.ToString();
                    }
                }

                // Motherboard Info
                using (var boardSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard"))
                {
                    foreach (var obj in boardSearcher.Get())
                    {
                        info.Motherboard = obj["Product"]?.ToString();
                    }
                }

                // IP Info
                using (var netSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"))
                {
                    foreach (ManagementObject mo in netSearcher.Get())
                    {
                        string[] ip = (string[])mo["IPAddress"];
                        string[] subnet = (string[])mo["IPSubnet"];
                        string[] gateway = (string[])mo["DefaultIPGateway"];
                        string[] dns = (string[])mo["DNSServerSearchOrder"];

                        if (ip != null && ip.Length > 0)
                            info.IPConfig.IPv4Address = ip.FirstOrDefault(a => a.Contains("."));

                        if (subnet != null && subnet.Length > 0)
                            info.IPConfig.SubnetMask = subnet.FirstOrDefault();

                        if (gateway != null && gateway.Length > 0)
                            info.IPConfig.DefaultGateway = gateway.FirstOrDefault();

                        if (dns != null)
                            info.IPConfig.DnsServers.AddRange(dns);

                        break; // Use first adapter only
                    }

                    info.IPConfig.Hostname = Environment.MachineName;
                }
            }
            catch (Exception ex)
            {
                info.Error = $"[Exception] {ex.Message}";
            }

            return info;
        }
    }
}


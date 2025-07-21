using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Management;
using MonitoringAgent.Models;

namespace MonitoringAgentGUI.Modules
{
    public static class HardwareMonitor
    {
        public static HardwareInfo GetHardwareData()
        {
            var info = new HardwareInfo();

            try
            {
                // Get CPU
                using var cpuSearcher = new ManagementObjectSearcher("select * from Win32_Processor");
                foreach (var obj in cpuSearcher.Get())
                {
                    info.CPU = obj["Name"]?.ToString();
                }

                // Get RAM
                using var memSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (var obj in memSearcher.Get())
                {
                    double total = Convert.ToDouble(obj["TotalVisibleMemorySize"]) / 1024;
                    double free = Convert.ToDouble(obj["FreePhysicalMemory"]) / 1024;
                    info.TotalRAM = $"{Math.Round(total)} MB";
                    info.FreeRAM = $"{Math.Round(free)} MB";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] HardwareMonitor: {ex.Message}");
                info.CPU = "Error";
                info.TotalRAM = "Error";
                info.FreeRAM = "Error";
            }

            return info;
        }
    }
}

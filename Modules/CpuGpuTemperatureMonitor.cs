using System;
using System.Collections.Generic;
using System.Linq;
using MonitoringAgent.Models;
using System.Management;

namespace MonitoringAgent.Modules
{
    public static class CpuGpuTemperatureMonitor
    {
        public static CpuAndGpuTemperatureInfo GetCpuAndGpuInfo()
        {
            var info = new CpuAndGpuTemperatureInfo();

            try
            {
                // CPU Info
                using (var searcher = new ManagementObjectSearcher("select * from Win32_Processor"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        info.CpuName = obj["Name"]?.ToString();
                        info.CpuCoreCount = Convert.ToInt32(obj["NumberOfCores"] ?? 0);
                        info.CpuCurrentClockSpeedMHz = Convert.ToSingle(obj["CurrentClockSpeed"] ?? 0);
                        info.CpuLoadPercentage = Convert.ToSingle(obj["LoadPercentage"] ?? 0);
                        break;
                    }
                }

                // GPU Info
                using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        info.GpuName = obj["Name"]?.ToString();
                        info.GpuDriverVersion = obj["DriverVersion"]?.ToString();

                        if (ulong.TryParse(obj["AdapterRAM"]?.ToString(), out ulong bytes))
                        {
                            info.GpuMemoryTotalMB = bytes / (1024 * 1024);
                        }

                        break;
                    }
                }

                // GPU Temp: not available via WMI, keep null
                info.GpuTemperatureCelsius = null;

                // CPU Temp: also not reliable via WMI, keep null
                info.CpuTemperatureCelsius = null;
            }
            catch (Exception ex)
            {
                info.Error = ex.Message;
            }

            return info;
        }
    }
}

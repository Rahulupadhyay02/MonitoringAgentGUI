using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class CpuAndGpuTemperatureInfo
    {
        // CPU Details
        public float? CpuTemperatureCelsius { get; set; }
        public string CpuName { get; set; }
        public int CpuCoreCount { get; set; }
        public float? CpuCurrentClockSpeedMHz { get; set; }
        public float? CpuLoadPercentage { get; set; }

        // GPU Details
        public string GpuName { get; set; }
        public string GpuDriverVersion { get; set; }
        public float? GpuTemperatureCelsius { get; set; }
        public ulong? GpuMemoryTotalMB { get; set; }
        public ulong? GpuMemoryFreeMB { get; set; }

        // Error log
        public string Error { get; set; }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace MonitoringAgent.Models
{
    public class HardwareInfo
    {
        public string CPU { get; set; }
        public string TotalRAM { get; set; }
        public string FreeRAM { get; set; }
    }
}

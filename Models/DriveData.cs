using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class DriveData
    {
        public string Name { get; set; }
        public string DriveType { get; set; }
        public string Format { get; set; }
        public long TotalSizeGB { get; set; }
        public long FreeSpaceGB { get; set; }
        public string VolumeLabel { get; set; }
        public string Error { get; set; }
    }
}


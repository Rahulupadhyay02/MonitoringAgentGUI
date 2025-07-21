using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonitoringAgent.Models
{
    public class DriveHealthInfo
    {
        public string DeviceID { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }          // "OK", "Pred Fail", etc.
        public string InterfaceType { get; set; }
        public string MediaType { get; set; }
        public long SizeBytes { get; set; }
        public string Error { get; set; }
    }
}


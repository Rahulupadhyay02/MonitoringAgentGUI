using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class UsbDeviceInfo
    {
        public string DeviceID { get; set; }
        public string PNPDeviceID { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public string Error { get; set; }
    }
}


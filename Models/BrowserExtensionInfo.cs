using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class BrowserExtensionInfo
    {
        public string Browser { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Version { get; set; }
        public bool IsEnabled { get; set; }
    }
}

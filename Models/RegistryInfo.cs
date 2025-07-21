using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class RegistryInfo
    {
        public string Hive { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
        public string Error { get; set; }
    }
}

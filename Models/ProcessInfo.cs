using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class ProcessInfo
    {
        public string Name { get; set; }
        public int PID { get; set; }
        public int ParentPID { get; set; }
        public DateTime? StartTime { get; set; }
        public string CPUTime { get; set; }
        public double MemoryMB { get; set; }
        public double VirtualMemoryMB { get; set; }
        public string CommandLine { get; set; }
        public string FilePath { get; set; }
        public bool IsResponding { get; set; }
        public string UserName { get; set; }
        public bool IsElevated { get; set; }
        public string Error { get; set; }
    }
}

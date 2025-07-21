using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MonitoringAgent.Models
{
    public class PatchInfo
    {
        public int TotalCount { get; set; }
        public DateTime? LastInstalledOn { get; set; }

        public List<string> InstalledUpdates { get; set; }

        public string Error { get; set; }
    }
}

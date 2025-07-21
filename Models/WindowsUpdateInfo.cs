using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringAgent.Models
{
    public class WindowsUpdateInfo
    {
        public DateTime? LastCheckedTime { get; set; }
        public DateTime? LastInstalledTime { get; set; } = null; // optional, not directly retrieved
        public int PendingUpdates { get; set; }
        public bool RebootRequired { get; set; }
        public List<UpdateItem> Updates { get; set; }
        public string Error { get; set; }
    }

    public class UpdateItem
    {
        public string Title { get; set; }
        public string KB { get; set; }
        public string Status { get; set; }
        public long? Size { get; set; }
    }
}

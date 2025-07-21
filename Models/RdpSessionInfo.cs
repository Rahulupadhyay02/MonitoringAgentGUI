using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonitoringAgent.Models
{
    public class RdpSessionInfo
    {
        public int? SessionID { get; set; }
        public string UserName { get; set; }
        public string SessionState { get; set; }
        public DateTime? LogonTime { get; set; }
        public string Error { get; set; }
    }
}

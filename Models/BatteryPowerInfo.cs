using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonitoringAgent.Models
{
    public class BatteryPowerInfo
    {
        public bool IsBatteryPresent { get; set; }
        public string PowerLineStatus { get; set; }
        public int BatteryLifePercent { get; set; }
        public TimeSpan BatteryLifeRemaining { get; set; }
        public string Error { get; set; }
    }
}


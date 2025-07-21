using MonitoringAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MonitoringAgent.Modules
{
    public static class SystemUptimeMonitor
    {
        public static SystemUptimeInfo GetUptimeInfo()
        {
            try
            {
                var bootTime = DateTime.Now - TimeSpan.FromMilliseconds(Environment.TickCount64);
                var uptimeSeconds = TimeSpan.FromMilliseconds(Environment.TickCount64).TotalSeconds;

                return new SystemUptimeInfo
                {
                    LastBootTime = bootTime,
                    UptimeSeconds = uptimeSeconds,
                    UptimeReadable = TimeSpan.FromSeconds(uptimeSeconds).ToString(@"dd\.hh\:mm\:ss"),
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new SystemUptimeInfo { Error = "[Exception] " + ex.Message };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonitoringAgent.Models;
using System.Windows.Forms; // Ensure your .csproj uses `<UseWindowsForms>true</UseWindowsForms>`

namespace MonitoringAgent.Modules
{
    public static class BatteryPowerMonitor
    {
        public static BatteryPowerInfo GetBatteryInfo()
        {
            try
            {
                PowerStatus powerStatus = SystemInformation.PowerStatus;

                return new BatteryPowerInfo
                {
                    IsBatteryPresent = SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery,
                    PowerLineStatus = powerStatus.PowerLineStatus.ToString(),
                    BatteryLifePercent = (int)(powerStatus.BatteryLifePercent * 100),
                    BatteryLifeRemaining = TimeSpan.FromSeconds(powerStatus.BatteryLifeRemaining),
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new BatteryPowerInfo
                {
                    Error = "[Exception] " + ex.Message
                };
            }
        }
    }
}


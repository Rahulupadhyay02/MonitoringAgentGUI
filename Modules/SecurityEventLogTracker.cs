using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class SecurityEventLogTracker
    {
        public static List<SecurityEvent> GetCriticalSecurityEvents()
        {
            var events = new List<SecurityEvent>();
            try
            {
                string query = "*[System[(EventID=4625 or EventID=4624 or EventID=4740)]]"; // login failed, success, lockout
                var eventLogQuery = new EventLogQuery("Security", PathType.LogName, query)
                {
                    ReverseDirection = true,
                    TolerateQueryErrors = true
                };

                using var reader = new EventLogReader(eventLogQuery);

                for (int i = 0; i < 50; i++) // Get last 50 events
                {
                    var log = reader.ReadEvent();
                    if (log == null) break;

                    events.Add(new SecurityEvent
                    {
                        EventID = log.Id,
                        ProviderName = log.ProviderName,
                        Message = log.FormatDescription(),
                        TimeCreated = log.TimeCreated
                    });
                }
            }
            catch (Exception ex)
            {
                events.Add(new SecurityEvent { Error = "[Exception] " + ex.Message });
            }

            return events;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class EventLogreader
    {
        public static List<EventLogEntryInfo> GetRecentLogs(int maxEntries = 50)
        {
            var logs = new List<EventLogEntryInfo>();
            string[] logTypes = { "Application", "System", "Security" };

            foreach (string logType in logTypes)
            {
                try
                {
                    EventLog eventLog = new EventLog(logType);
                    var entries = eventLog.Entries.Cast<EventLogEntry>()
                                        .OrderByDescending(e => e.TimeGenerated)
                                        .Take(maxEntries);

                    foreach (var entry in entries)
                    {
                        logs.Add(new EventLogEntryInfo
                        {
                            LogName = logType,
                            Source = entry.Source,
                            EntryType = entry.EntryType.ToString(),
                            Message = entry.Message,
                            TimeGenerated = entry.TimeGenerated
                        });
                    }
                }
                catch (Exception ex)
                {
                    logs.Add(new EventLogEntryInfo
                    {
                        LogName = logType,
                        Source = "Error",
                        EntryType = "Exception",
                        Message = ex.Message,
                        TimeGenerated = DateTime.Now
                    });
                }
            }

            return logs;
        }
    }
}

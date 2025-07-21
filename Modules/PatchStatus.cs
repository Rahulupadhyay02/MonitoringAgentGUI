using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class PatchStatus
    {
        public static PatchInfo GetPatchInfo()
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = "Get-HotFix | Select-Object Description, HotFixID, InstalledOn | ConvertTo-Json -Compress",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using var process = Process.Start(startInfo);
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    return new PatchInfo { Error = $"[PowerShell Error] {error}" };
                }

                List<HotFixInline> updates;
                if (output.TrimStart().StartsWith("{"))
                {
                    var single = JsonSerializer.Deserialize<HotFixInline>(output);
                    updates = new List<HotFixInline> { single };
                }
                else
                {
                    updates = JsonSerializer.Deserialize<List<HotFixInline>>(output);
                }

                var installedDates = new List<DateTime>();
                var updateNames = new List<string>();

                foreach (var update in updates)
                {
                    if (update?.InstalledOn?.DateTime != null && DateTime.TryParse(update.InstalledOn.DateTime, out var parsedDate))
                        installedDates.Add(parsedDate);

                    if (!string.IsNullOrWhiteSpace(update?.HotFixID))
                        updateNames.Add(update.HotFixID);
                }

                return new PatchInfo
                {
                    TotalCount = updates.Count,
                    LastInstalledOn = installedDates.Count > 0 ? installedDates.Max() : null,
                    InstalledUpdates = updateNames,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new PatchInfo { Error = $"[Exception] {ex.Message}" };
            }
        }

        // Inline model
        private class HotFixInline
        {
            public string Description { get; set; }
            public string HotFixID { get; set; }
            public InstalledDate InstalledOn { get; set; }
        }

        private class InstalledDate
        {
            public string value { get; set; }
            public string DateTime { get; set; }
        }
    }
}


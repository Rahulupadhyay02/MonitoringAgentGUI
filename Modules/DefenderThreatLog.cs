using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using MonitoringAgent.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MonitoringAgent.Modules
{
    public static class DefenderThreatLog
    {
        public static List<DefenderThreat> GetDefenderThreats()
        {
            var threatList = new List<DefenderThreat>();

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = "Get-MpThreatDetection | Select-Object ThreatName,Severity,ActionSuccess,InitialDetectionTime,DetectionSourceType,Status | ConvertTo-Json -Compress",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(startInfo);
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    threatList.Add(new DefenderThreat { Error = $"[PowerShell Error] {error}" });
                    return threatList;
                }

                if (string.IsNullOrWhiteSpace(output))
                {
                    threatList.Add(new DefenderThreat { Error = "No output returned from PowerShell." });
                    return threatList;
                }

                if (output.Trim().StartsWith("{"))
                {
                    var single = JsonSerializer.Deserialize<DefenderThreatRaw>(output);
                    threatList.Add(ConvertToThreat(single));
                }
                else
                {
                    var rawList = JsonSerializer.Deserialize<List<DefenderThreatRaw>>(output);
                    foreach (var raw in rawList)
                    {
                        threatList.Add(ConvertToThreat(raw));
                    }
                }
            }
            catch (Exception ex)
            {
                threatList.Add(new DefenderThreat { Error = $"[Exception] {ex.Message}" });
            }

            return threatList;
        }

        private class DefenderThreatRaw
        {
            public string ThreatName { get; set; }
            public string Severity { get; set; }
            public bool ActionSuccess { get; set; }
            public DateTime? InitialDetectionTime { get; set; }
            public string DetectionSourceType { get; set; }
            public string Status { get; set; }
        }

        private static DefenderThreat ConvertToThreat(DefenderThreatRaw raw)
        {
            return new DefenderThreat
            {
                ThreatName = raw.ThreatName,
                Severity = raw.Severity,
                ActionTaken = raw.ActionSuccess ? "Success" : "Failed",
                DetectionTime = raw.InitialDetectionTime,
                Source = raw.DetectionSourceType,
                Status = raw.Status
            };
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitoringAgent.Models;
using System.Diagnostics;
using System.Text.Json;


namespace MonitoringAgent.Modules
{
    public static class FirewallStatus
    {
        public static FirewallInfo GetFirewallInfo()
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = "Get-NetFirewallProfile | Select-Object Name, Enabled, DefaultInboundAction, DefaultOutboundAction | ConvertTo-Json -Compress",
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
                    return new FirewallInfo { Error = $"[PowerShell Error] {error}" };
                }

                List<FirewallProfile> profiles;
                if (output.Trim().StartsWith("{"))
                {
                    var single = JsonSerializer.Deserialize<FirewallProfile>(output);
                    profiles = new List<FirewallProfile> { single };
                }
                else
                {
                    profiles = JsonSerializer.Deserialize<List<FirewallProfile>>(output);
                }

                bool domain = false, priv = false, pub = false;
                int? inbound = null, outbound = null;

                foreach (var profile in profiles)
                {
                    switch (profile.Name?.ToLowerInvariant())
                    {
                        case "domain":
                            domain = profile.IsEnabled;
                            inbound = profile.DefaultInboundAction;
                            outbound = profile.DefaultOutboundAction;
                            break;
                        case "private":
                            priv = profile.IsEnabled;
                            break;
                        case "public":
                            pub = profile.IsEnabled;
                            break;
                    }
                }

                // Get rule count
                var countInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = "(Get-NetFirewallRule).Count",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using var ruleProc = Process.Start(countInfo);
                string ruleOutput = ruleProc.StandardOutput.ReadToEnd();
                ruleProc.WaitForExit();

                int ruleCount = int.TryParse(ruleOutput.Trim(), out var result) ? result : 0;

                return new FirewallInfo
                {
                    IsFirewallEnabled = domain || priv || pub,
                    DomainEnabled = domain,
                    PrivateEnabled = priv,
                    PublicEnabled = pub,
                    DefaultInboundAction = inbound,
                    DefaultOutboundAction = outbound,
                    RuleCount = ruleCount,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new FirewallInfo { Error = $"[Exception] {ex.Message}" };
            }
        }

    }
}


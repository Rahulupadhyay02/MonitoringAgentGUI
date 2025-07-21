using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using MonitoringAgent.Models;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace MonitoringAgent.Modules
{
    public static class WindowsUpdateStatus
    {
        public static WindowsUpdateInfo GetUpdateInfo()
        {
            var updateInfo = new WindowsUpdateInfo();

            try
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.AddScript(@"
    $session = New-Object -ComObject Microsoft.Update.Session
    $searcher = $session.CreateUpdateSearcher()
    $results = $searcher.Search('IsInstalled=0')

    $updates = @()
    foreach ($update in $results.Updates) {
        $size = try { 
            [int64]$update.MaxDownloadSize 
        } catch { 
            $null 
        }

        $updates += [PSCustomObject]@{
            Title  = $update.Title
            KB     = $update.KBArticleIDs | Select-Object -First 1
            Status = if ($update.InstallationBehavior.CanRequestUserInput) { 'Interactive' } else { 'Silent' }
            Size   = $size
        }
    }

    $object = [PSCustomObject]@{
        LastCheckedTime   = $results.SearchStartTime
        PendingUpdates    = $results.Updates.Count
        Updates           = $updates
        RebootRequired    = (Get-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\RebootRequired' -ErrorAction SilentlyContinue) -ne $null
    }
    $object | ConvertTo-Json -Depth 3
");

                    

                    var results = ps.Invoke();

                    if (ps.HadErrors)
                    {
                        updateInfo.Error = string.Join(" | ", ps.Streams.Error.ReadAll());
                    }
                    else if (results.Count > 0)
                    {
                        updateInfo = JsonSerializer.Deserialize<WindowsUpdateInfo>(results[0].ToString(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                updateInfo.Error = "[Exception] " + ex.Message;
            }

            return updateInfo;
        }
    }
}

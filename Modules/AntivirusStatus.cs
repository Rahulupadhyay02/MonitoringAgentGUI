using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using MonitoringAgent.Models;
using System.Management;

namespace MonitoringAgent.Modules
{
    public static class AntivirusStatus
    {
        public static AntivirusInfo GetAntivirusInfo()
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = "Get-CimInstance -Namespace root/SecurityCenter2 -ClassName AntiVirusProduct | Select-Object displayName,productState,timestamp | ConvertTo-Json -Compress",
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
                    return new AntivirusInfo { Error = "[PowerShell Error] " + error };

                if (string.IsNullOrWhiteSpace(output))
                    return new AntivirusInfo { Error = "No antivirus information found." };

                var result = JsonSerializer.Deserialize<JsonElement>(output);

                JsonElement antivirusElement = result.ValueKind == JsonValueKind.Array && result.GetArrayLength() > 0
                    ? result[0]
                    : result;

                string productName = antivirusElement.GetProperty("displayName").GetString();
                int productState = antivirusElement.GetProperty("productState").GetInt32();
                string timestamp = antivirusElement.GetProperty("timestamp").GetString();

                bool realTimeEnabled = ((productState >> 0) & 0x10) == 0x10;

                return new AntivirusInfo
                {
                    ProductName = productName,
                    ProductState = productState.ToString("X"),
                    RealTimeProtectionEnabled = realTimeEnabled,
                    LastScanDate = DateTime.TryParse(timestamp, out var parsed) ? parsed : null,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new AntivirusInfo { Error = "[Exception] " + ex.Message };
            }
        }
    }
}


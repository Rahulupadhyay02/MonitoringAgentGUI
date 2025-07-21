using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MonitoringAgent.Models;


namespace MonitoringAgent.Modules
{
    public static class RegistryMonitor
    {
        public static List<RegistryInfo> GetRegistryInfo()
        {
            var registryEntries = new List<RegistryInfo>();

            try
            {
                // Check auto-start programs
                ReadRegistryKey(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", registryEntries);

                // Check RDP access
                ReadRegistryValue(RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Terminal Server", "fDenyTSConnections", registryEntries);

                // Windows Defender policies
                ReadRegistryKey(RegistryHive.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows Defender", registryEntries);
            }
            catch (Exception ex)
            {
                registryEntries.Add(new RegistryInfo { Error = $"[Exception] {ex.Message}" });
            }

            return registryEntries;
        }

        private static void ReadRegistryKey(RegistryHive hive, string subKeyPath, List<RegistryInfo> entries)
        {
            using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
            using var subKey = baseKey.OpenSubKey(subKeyPath);

            if (subKey != null)
            {
                foreach (var valueName in subKey.GetValueNames())
                {
                    var val = subKey.GetValue(valueName);
                    var kind = subKey.GetValueKind(valueName).ToString();

                    entries.Add(new RegistryInfo
                    {
                        Hive = hive.ToString(),
                        Path = subKeyPath,
                        Name = valueName,
                        Value = val,
                        Type = kind
                    });
                }
            }
        }

        private static void ReadRegistryValue(RegistryHive hive, string subKeyPath, string valueName, List<RegistryInfo> entries)
        {
            using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
            using var subKey = baseKey.OpenSubKey(subKeyPath);

            if (subKey != null && subKey.GetValue(valueName) != null)
            {
                var val = subKey.GetValue(valueName);
                var kind = subKey.GetValueKind(valueName).ToString();

                entries.Add(new RegistryInfo
                {
                    Hive = hive.ToString(),
                    Path = subKeyPath,
                    Name = valueName,
                    Value = val,
                    Type = kind
                });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MonitoringAgent.Models;
using System.Diagnostics;


namespace MonitoringAgent.Modules
{
    public static class SoftwareAudit
    {
        public static SoftwareAuditResult GetAudit()
        {
            var list = new List<InstalledSoftware>();

            // 64-bit
            list.AddRange(ReadRegistryView(RegistryView.Registry64));

            // 32-bit
            list.AddRange(ReadRegistryView(RegistryView.Registry32));

            // Get running processes
            var processes = Process.GetProcesses();
            var processNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var proc in processes)
            {
                try { processNames.Add(proc.ProcessName); } catch { }
            }

            // Enrich status
            foreach (var item in list)
            {
                string cleanName = item.Name.Split(' ')[0]; // crude match
                item.Status = processNames.Contains(cleanName) ? "Running" : "Idle";

                // Last used - use registry RunMRU or other (approximated)
                item.LastUsedTime = null; // (Optional: populate if you wish)
            }

            return new SoftwareAuditResult
            {
                TotalInstalled = list.Count,
                ActiveCount = list.FindAll(s => s.Status == "Running").Count,
                IdleCount = list.FindAll(s => s.Status == "Idle").Count,
                InstalledSoftware = list
            };
        }

        private static List<InstalledSoftware> ReadRegistryView(RegistryView view)
        {
            var list = new List<InstalledSoftware>();

            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
            using (RegistryKey uninstallKey = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                if (uninstallKey == null) return list;

                foreach (string subKeyName in uninstallKey.GetSubKeyNames())
                {
                    using (RegistryKey subKey = uninstallKey.OpenSubKey(subKeyName))
                    {
                        if (subKey == null) continue;

                        string name = subKey.GetValue("DisplayName") as string;
                        string version = subKey.GetValue("DisplayVersion") as string;
                        string publisher = subKey.GetValue("Publisher") as string;

                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            list.Add(new InstalledSoftware
                            {
                                Name = name,
                                Version = version ?? "Unknown",
                                Publisher = publisher ?? "Unknown"
                            });
                        }
                    }
                }
            }

            return list;
        }
    }

    public class SoftwareAuditResult
    {
        public int TotalInstalled { get; set; }
        public int ActiveCount { get; set; }
        public int IdleCount { get; set; }
        public List<InstalledSoftware> InstalledSoftware { get; set; }
    }
}

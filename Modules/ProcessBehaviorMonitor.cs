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
    public static class ProcessBehaviorMonitor
    {
        public static List<ProcessInfo> GetRunningProcesses()
        {
            var processes = new List<ProcessInfo>();

            try
            {
                // Use WMI to enrich process details
                var searcher = new ManagementObjectSearcher("SELECT ProcessId, CommandLine, ExecutablePath, ParentProcessId FROM Win32_Process");

                // Map WMI data by PID
                var processDetails = searcher.Get()
                    .Cast<ManagementObject>()
                    .ToDictionary(m => Convert.ToInt32(m["ProcessId"]), m => new
                    {
                        CommandLine = m["CommandLine"]?.ToString(),
                        ExecutablePath = m["ExecutablePath"]?.ToString(),
                        ParentPid = Convert.ToInt32(m["ParentProcessId"] ?? 0)
                    });

                foreach (var proc in Process.GetProcesses())
                {
                    try
                    {
                        var info = new ProcessInfo
                        {
                            Name = proc.ProcessName,
                            PID = proc.Id,
                            StartTime = GetSafeStartTime(proc),
                            CPUTime = proc.TotalProcessorTime.ToString(),
                            MemoryMB = Math.Round(proc.WorkingSet64 / 1024.0 / 1024.0, 2),
                            VirtualMemoryMB = Math.Round(proc.VirtualMemorySize64 / 1024.0 / 1024.0, 2),
                            IsResponding = proc.Responding,
                            FilePath = processDetails.ContainsKey(proc.Id) ? processDetails[proc.Id].ExecutablePath : null,
                            CommandLine = processDetails.ContainsKey(proc.Id) ? processDetails[proc.Id].CommandLine : null,
                            ParentPID = processDetails.ContainsKey(proc.Id) ? processDetails[proc.Id].ParentPid : 0,
                            IsElevated = IsProcessElevated(proc),
                            UserName = GetProcessUser(proc)
                        };

                        processes.Add(info);
                    }
                    catch (Exception ex)
                    {
                        processes.Add(new ProcessInfo
                        {
                            PID = proc.Id,
                            Name = proc.ProcessName,
                            Error = $"[Process Error] {ex.Message}"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                processes.Add(new ProcessInfo { Error = $"[Global Error] {ex.Message}" });
            }

            return processes;
        }

        private static DateTime? GetSafeStartTime(Process proc)
        {
            try { return proc.StartTime; }
            catch { return null; }
        }

        private static bool IsProcessElevated(Process process)
        {
            try
            {
                using var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                return new System.Security.Principal.WindowsPrincipal(identity)
                    .IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
            catch { return false; }
        }

        private static string GetProcessUser(Process process)
        {
            try
            {
                string query = $"SELECT * FROM Win32_Process WHERE ProcessId = {process.Id}";
                using var searcher = new ManagementObjectSearcher(query);
                foreach (ManagementObject obj in searcher.Get())
                {
                    object[] args = new object[] { string.Empty, string.Empty };
                    int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", args));
                    if (returnVal == 0)
                        return $"{args[1]}\\{args[0]}"; // Domain\User
                }
            }
            catch { }
            return null;
        }
    }
}


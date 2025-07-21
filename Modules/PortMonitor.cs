using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class PortMonitor
    {
        public static List<PortInfo> GetOpenPorts()
        {
            var ports = new List<PortInfo>();
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "netstat",
                    Arguments = "-ano",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var lines = output.Split('\n');

                foreach (var line in lines)
                {
                    if (line.StartsWith("  TCP") || line.StartsWith("  UDP"))
                    {
                        var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 5)
                        {
                            string protocol = parts[0];
                            string localAddress = parts[1];
                            string state = protocol == "TCP" ? parts[3] : "Listening";
                            int pid = int.TryParse(parts[^1], out var p) ? p : 0;

                            var portPart = localAddress.Split(':');
                            if (int.TryParse(portPart[^1], out int port))
                            {
                                string procName = "Unknown";
                                try
                                {
                                    var proc = Process.GetProcessById(pid);
                                    procName = proc.ProcessName;
                                }
                                catch { }

                                ports.Add(new PortInfo
                                {
                                    Port = port,
                                    Protocol = protocol,
                                    ProcessId = pid,
                                    ProcessName = procName,
                                    State = state
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ports.Add(new PortInfo { Error = "[Exception] " + ex.Message });
            }

            return ports;
        }
    }
}

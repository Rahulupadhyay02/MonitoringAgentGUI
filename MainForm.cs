using MonitoringAgent.Models;
using MonitoringAgent.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MonitoringAgentGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object? sender, EventArgs e)
        {
            LoadDriveInfo();
            LoadCpuGpuInfo();
            LoadBatteryInfo();
            LoadBrowserExtensions();
            LoadAntivirusInfo();
            LoadDeviceInfo();
            LoadSoftwareAudit();
            LoadFirewallInfo();
            LoadDefenderThreatLogs();
            LoadEventLogs();
            LoadHardwareInfo();
            LoadNetworkInfo();
            LoadPatchInfo();
            LoadPortMonitor();
            LoadProcessBehavior();
            LoadRdpSessions();
            LoadRegistryInfo();
            LoadSecurityEvents();
            LoadSystemUptime();
            LoadUsbDevices();
            LoadWindowsUpdates();
            LoadStatusMonitor();


        }

        private void btnStop_Click(object? sender, EventArgs e)
        {
            string message = "Monitoring stopped at " + DateTime.Now.ToString("g") + Environment.NewLine;

            txtDriveLogs.AppendText(message);
            txtCpuGpuLogs.AppendText(message);
            txtBatteryLogs.AppendText(message);
            txtBrowserLogs.AppendText(message);
            txtAntivirusLogs.AppendText(message);
            txtDeviceLogs.AppendText(message);
            txtFirewallLogs.AppendText(message);
            txtSoftwareLogs.AppendText(message);
            txtDefenderLogs.AppendText(message);
            txtEventLogs.AppendText(message);
            txtHardwareLogs.AppendText(message);
            txtNetworkLogs.AppendText(message);
            txtPatchLogs.AppendText(message);
            txtPortLogs.AppendText(message);
            txtProcessLogs.AppendText(message);
            txtRdpLogs.AppendText(message);
            txtRegistryLogs.AppendText(message);
            txtSecurityLogs.AppendText(message);
            txtUptimeLogs.AppendText(message);
            txtUsbLogs.AppendText(message);
            txtUpdateLogs.AppendText(message);
            txtStatusLogs.AppendText(message);

            MessageBox.Show("Monitoring has been stopped.", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnUpload_Click(object? sender, EventArgs e)
        {
            txtDriveLogs.AppendText("Uploading data to server...\r\n");
            // TODO: Add upload logic
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            try
            {
                // Create SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                    saveFileDialog.Title = "Export Logs";
                    saveFileDialog.FileName = "SystemLogs.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();

                        // Append logs with section headers
                        sb.AppendLine("===== Drive Info =====");
                        sb.AppendLine(txtDriveLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== CPU & GPU Info =====");
                        sb.AppendLine(txtCpuGpuLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Battery Power =====");
                        sb.AppendLine(txtBatteryLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Browser Extensions =====");
                        sb.AppendLine(txtBrowserLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Antivirus Info =====");
                        sb.AppendLine(txtAntivirusLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Device Info =====");
                        sb.AppendLine(txtDeviceLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Firewall Info =====");
                        sb.AppendLine(txtFirewallLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Software Audit =====");
                        sb.AppendLine(txtSoftwareLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Defender Threat Logs =====");
                        sb.AppendLine(txtDefenderLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Windows Event Logs =====");
                        sb.AppendLine(txtEventLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Hardware Info =====");
                        sb.AppendLine(txtHardwareLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Network Info =====");
                        sb.AppendLine(txtNetworkLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Patch Info =====");
                        sb.AppendLine(txtPatchLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Open Ports Monitor =====");
                        sb.AppendLine(txtPortLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Running Processes =====");
                        sb.AppendLine(txtProcessLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== RDP Sessions =====");
                        sb.AppendLine(txtRdpLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Registry Audit =====");
                        sb.AppendLine(txtRegistryLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Security Event Logs =====");
                        sb.AppendLine(txtSecurityLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== System Uptime Info =====");
                        sb.AppendLine(txtUptimeLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== USB Devices =====");
                        sb.AppendLine(txtUsbLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Windows Updates =====");
                        sb.AppendLine(txtUpdateLogs.Text);
                        sb.AppendLine();

                        sb.AppendLine("===== Drive Status Monitor (SMART) =====");
                        sb.AppendLine(txtStatusLogs.Text);
                        sb.AppendLine();

                        // Save to file
                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());

                        MessageBox.Show("Logs exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadDriveInfo()
        {
            txtDriveLogs.Clear();
            gridDriveInfo.Rows.Clear();
            gridDriveInfo.Columns.Clear();

            gridDriveInfo.Columns.Add("Name", "Name");
            gridDriveInfo.Columns.Add("Type", "Type");
            gridDriveInfo.Columns.Add("Format", "Format");
            gridDriveInfo.Columns.Add("TotalSizeGB", "Total Size (GB)");
            gridDriveInfo.Columns.Add("FreeSpaceGB", "Free Space (GB)");
            gridDriveInfo.Columns.Add("VolumeLabel", "Volume Label");
            gridDriveInfo.Columns.Add("Error", "Error");

            try
            {
                var drives = DriveInfoMonitor.GetDriveInfo();
                foreach (var drive in drives)
                {
                    gridDriveInfo.Rows.Add(
                        drive.Name,
                        drive.DriveType,
                        drive.Format,
                        drive.TotalSizeGB,
                        drive.FreeSpaceGB,
                        drive.VolumeLabel,
                        drive.Error
                    );
                }

                txtDriveLogs.AppendText("Drive Info Loaded Successfully.\r\n");
            }
            catch (Exception ex)
            {
                txtDriveLogs.AppendText($"[ERROR] Failed to load drive info: {ex.Message}\r\n");
            }
        }

        private void LoadCpuGpuInfo()
        {
            txtCpuGpuLogs.Clear();
            gridCpuGpuInfo.Rows.Clear();
            gridCpuGpuInfo.Columns.Clear();

            gridCpuGpuInfo.Columns.Add("CpuName", "CPU Name");
            gridCpuGpuInfo.Columns.Add("CpuCores", "Cores");
            gridCpuGpuInfo.Columns.Add("CpuClock", "Clock Speed (MHz)");
            gridCpuGpuInfo.Columns.Add("CpuLoad", "Load (%)");
            gridCpuGpuInfo.Columns.Add("GpuName", "GPU Name");
            gridCpuGpuInfo.Columns.Add("GpuDriver", "GPU Driver");
            gridCpuGpuInfo.Columns.Add("GpuMemory", "GPU Memory (MB)");
            gridCpuGpuInfo.Columns.Add("Error", "Error");

            try
            {
                var cpuGpu = CpuGpuTemperatureMonitor.GetCpuAndGpuInfo();

                gridCpuGpuInfo.Rows.Add(
                    cpuGpu.CpuName,
                    cpuGpu.CpuCoreCount,
                    cpuGpu.CpuCurrentClockSpeedMHz,
                    cpuGpu.CpuLoadPercentage,
                    cpuGpu.GpuName,
                    cpuGpu.GpuDriverVersion,
                    cpuGpu.GpuMemoryTotalMB,
                    cpuGpu.Error
                );

                txtCpuGpuLogs.AppendText("CPU & GPU Info Loaded Successfully.\r\n");
            }
            catch (Exception ex)
            {
                txtCpuGpuLogs.AppendText($"[ERROR] Failed to load CPU/GPU info: {ex.Message}\r\n");
            }
        }

        private void LoadBatteryInfo()
        {
            txtBatteryLogs.Clear();
            gridBatteryPower.Rows.Clear();
            gridBatteryPower.Columns.Clear();

            gridBatteryPower.Columns.Add("BatteryLifePercent", "Battery (%)");
            gridBatteryPower.Columns.Add("PowerLineStatus", "Power Status");
            gridBatteryPower.Columns.Add("BatteryLifeRemaining", "Battery Time Left");
            gridBatteryPower.Columns.Add("IsBatteryPresent", "Battery Present");
            gridBatteryPower.Columns.Add("Error", "Error");

            try
            {
                var battery = BatteryPowerMonitor.GetBatteryInfo();

                gridBatteryPower.Rows.Add(
                    battery.BatteryLifePercent,
                    battery.PowerLineStatus,
                    battery.BatteryLifeRemaining.ToString(@"hh\:mm\:ss"),
                    battery.IsBatteryPresent,
                    battery.Error
                );

                txtBatteryLogs.AppendText("Battery & Power Info Loaded Successfully.\r\n");
            }
            catch (Exception ex)
            {
                txtBatteryLogs.AppendText($"[ERROR] Failed to load battery info: {ex.Message}\r\n");
            }
        }

        private void LoadBrowserExtensions()
        {
            txtBrowserLogs.Clear();
            gridBrowserExtensions.Rows.Clear();
            gridBrowserExtensions.Columns.Clear();

            gridBrowserExtensions.Columns.Add("Browser", "Browser");
            gridBrowserExtensions.Columns.Add("Name", "Extension Name");
            gridBrowserExtensions.Columns.Add("ID", "Extension ID");
            gridBrowserExtensions.Columns.Add("Version", "Version");
            gridBrowserExtensions.Columns.Add("IsEnabled", "Enabled");

            try
            {
                var extensions = BrowserExtensionAudit.GetInstalledExtensions();

                foreach (var ext in extensions)
                {
                    gridBrowserExtensions.Rows.Add(
                        ext.Browser,
                        ext.Name,
                        ext.ID,
                        ext.Version,
                        ext.IsEnabled
                    );
                }

                txtBrowserLogs.AppendText($"Loaded {extensions.Count} browser extensions.\r\n");
            }
            catch (Exception ex)
            {
                txtBrowserLogs.AppendText($"[ERROR] Failed to load browser extensions: {ex.Message}\r\n");
            }
        }

        private void LoadAntivirusInfo()
        {
            var data = AntivirusStatus.GetAntivirusInfo();

            if (data != null)
            {
                gridAntivirus.DataSource = new List<AntivirusInfo> { data };
                txtAntivirusLogs.Text = data.Error ?? $"Loaded antivirus info for: {data.ProductName}";
            }
            else
            {
                txtAntivirusLogs.Text = "No antivirus data available.";
            }
        }

        private void LoadDeviceInfo()
        {
            try
            {
                var device = DeviceInfoMonitor.GetDeviceInfo();

                var list = new List<DeviceInfo> { device };
                gridDeviceInfo.DataSource = list;

                txtDeviceLogs.Text = device.Error ?? "Device info loaded successfully.";
            }
            catch (Exception ex)
            {
                txtDeviceLogs.Text = "[Exception] " + ex.Message;
            }
        }

        private void LoadFirewallInfo()
        {
            try
            {
                var info = FirewallStatus.GetFirewallInfo();

                var list = new List<FirewallInfo> { info };
                gridFirewall.DataSource = list;

                txtFirewallLogs.Text = info.Error ?? "Firewall info loaded successfully.";
            }
            catch (Exception ex)
            {
                txtFirewallLogs.Text = "[Exception] " + ex.Message;
            }
        }

        private void LoadSoftwareAudit()
        {
            try
            {
                var audit = SoftwareAudit.GetAudit();

                gridSoftwareAudit.Rows.Clear();
                gridSoftwareAudit.Columns.Clear();

                gridSoftwareAudit.Columns.Add("Name", "Name");
                gridSoftwareAudit.Columns.Add("Version", "Version");
                gridSoftwareAudit.Columns.Add("Publisher", "Publisher");
                gridSoftwareAudit.Columns.Add("Status", "Status");

                foreach (var sw in audit.InstalledSoftware)
                {
                    gridSoftwareAudit.Rows.Add(
                        sw.Name,
                        sw.Version,
                        sw.Publisher,
                        sw.Status
                    );
                }

                txtSoftwareLogs.Text = $"Installed: {audit.TotalInstalled}, Running: {audit.ActiveCount}, Idle: {audit.IdleCount}";
            }
            catch (Exception ex)
            {
                txtSoftwareLogs.Text = "[ERROR] " + ex.Message;
            }
        }

        private void LoadDefenderThreatLogs()
        {
            try
            {
                var threats = DefenderThreatLog.GetDefenderThreats();

                gridDefenderThreats.Rows.Clear();
                gridDefenderThreats.Columns.Clear();

                gridDefenderThreats.Columns.Add("ThreatName", "Threat Name");
                gridDefenderThreats.Columns.Add("Severity", "Severity");
                gridDefenderThreats.Columns.Add("ActionTaken", "Action Taken");
                gridDefenderThreats.Columns.Add("DetectionTime", "Detected At");
                gridDefenderThreats.Columns.Add("Source", "Source");
                gridDefenderThreats.Columns.Add("Status", "Status");
                gridDefenderThreats.Columns.Add("Error", "Error");

                foreach (var t in threats)
                {
                    gridDefenderThreats.Rows.Add(
                        t.ThreatName,
                        t.Severity,
                        t.ActionTaken,
                        t.DetectionTime,
                        t.Source,
                        t.Status,
                        t.Error
                    );
                }

                txtDefenderLogs.Text = $"Loaded {threats.Count} Defender threats.";
            }
            catch (Exception ex)
            {
                txtDefenderLogs.Text = $"[ERROR] {ex.Message}";
            }
        }

        private void LoadEventLogs()
        {
            txtEventLogs.Clear();
            gridEventLogs.Rows.Clear();
            gridEventLogs.Columns.Clear();

            gridEventLogs.Columns.Add("LogName", "Log");
            gridEventLogs.Columns.Add("Source", "Source");
            gridEventLogs.Columns.Add("EntryType", "Type");
            gridEventLogs.Columns.Add("Message", "Message");
            gridEventLogs.Columns.Add("TimeGenerated", "Time");

            try
            {
                var logs = EventLogreader.GetRecentLogs();

                foreach (var log in logs)
                {
                    gridEventLogs.Rows.Add(
                        log.LogName,
                        log.Source,
                        log.EntryType,
                        log.Message.Length > 100 ? log.Message.Substring(0, 100) + "..." : log.Message,
                        log.TimeGenerated.ToString("g")
                    );
                }

                txtEventLogs.AppendText($"Loaded {logs.Count} recent log entries.\r\n");
            }
            catch (Exception ex)
            {
                txtEventLogs.AppendText($"[ERROR] Failed to load event logs: {ex.Message}\r\n");
            }
        }
        private void LoadHardwareInfo()
        {
            txtHardwareLogs.Clear();
            gridHardware.Rows.Clear();
            gridHardware.Columns.Clear();

            gridHardware.Columns.Add("CPU", "CPU");
            gridHardware.Columns.Add("TotalRAM", "Total RAM");
            gridHardware.Columns.Add("FreeRAM", "Free RAM");

            try
            {
                var data = MonitoringAgentGUI.Modules.HardwareMonitor.GetHardwareData();

                gridHardware.Rows.Add(
                    data.CPU,
                    data.TotalRAM,
                    data.FreeRAM
                );

                txtHardwareLogs.AppendText("Hardware info loaded successfully.\r\n");
            }
            catch (Exception ex)
            {
                txtHardwareLogs.AppendText($"[ERROR] Failed to load hardware info: {ex.Message}\r\n");
            }
        }
        private void LoadNetworkInfo()
        {
            txtNetworkLogs.Clear();
            gridNetwork.Rows.Clear();
            gridNetwork.Columns.Clear();

            gridNetwork.Columns.Add("Name", "Name");
            gridNetwork.Columns.Add("Description", "Description");
            gridNetwork.Columns.Add("IPv4Address", "IPv4 Address");
            gridNetwork.Columns.Add("SubnetMask", "Subnet Mask");
            gridNetwork.Columns.Add("Gateway", "Gateway");
            gridNetwork.Columns.Add("DNS", "DNS");
            gridNetwork.Columns.Add("IsUp", "Is Up");

            try
            {
                var data = NetworkMonitor.GetNetworkInfo();

                if (!string.IsNullOrEmpty(data.Error))
                {
                    txtNetworkLogs.AppendText(data.Error + "\r\n");
                    return;
                }

                foreach (var adapter in data.Adapters)
                {
                    gridNetwork.Rows.Add(
                        adapter.Name,
                        adapter.Description,
                        adapter.IPv4Address,
                        adapter.SubnetMask,
                        adapter.Gateway,
                        adapter.DNS,
                        adapter.IsUp
                    );
                }

                txtNetworkLogs.AppendText("Network info loaded successfully.\r\n");
            }
            catch (Exception ex)
            {
                txtNetworkLogs.AppendText($"[ERROR] {ex.Message}\r\n");
            }
        }
        private void LoadPatchInfo()
        {
            txtPatchLogs.Clear();
            gridPatchInfo.Rows.Clear();
            gridPatchInfo.Columns.Clear();

            gridPatchInfo.Columns.Add("TotalCount", "Total Patches");
            gridPatchInfo.Columns.Add("LastInstalledOn", "Last Installed On");
            gridPatchInfo.Columns.Add("InstalledUpdates", "Installed Updates");
            gridPatchInfo.Columns.Add("Error", "Error");

            try
            {
                var patch = PatchStatus.GetPatchInfo();

                gridPatchInfo.Rows.Add(
                    patch.TotalCount,
                    patch.LastInstalledOn?.ToString("yyyy-MM-dd HH:mm"),
                    string.Join(", ", patch.InstalledUpdates ?? new List<string>()),
                    patch.Error
                );

                txtPatchLogs.AppendText(patch.Error ?? "Patch info loaded successfully.");
            }
            catch (Exception ex)
            {
                txtPatchLogs.AppendText($"[ERROR] {ex.Message}");
            }
        }
        private void LoadPortMonitor()
        {
            txtPortLogs.Clear();
            gridPortMonitor.Rows.Clear();
            gridPortMonitor.Columns.Clear();

            gridPortMonitor.Columns.Add("Port", "Port");
            gridPortMonitor.Columns.Add("Protocol", "Protocol");
            gridPortMonitor.Columns.Add("ProcessName", "Process");
            gridPortMonitor.Columns.Add("ProcessId", "PID");
            gridPortMonitor.Columns.Add("State", "State");
            gridPortMonitor.Columns.Add("Error", "Error");

            try
            {
                var ports = PortMonitor.GetOpenPorts();

                foreach (var port in ports)
                {
                    gridPortMonitor.Rows.Add(
                        port.Port,
                        port.Protocol,
                        port.ProcessName,
                        port.ProcessId,
                        port.State,
                        port.Error
                    );
                }

                txtPortLogs.AppendText($"Loaded {ports.Count} port entries.");
            }
            catch (Exception ex)
            {
                txtPortLogs.AppendText($"[ERROR] {ex.Message}");
            }
        }
        private void LoadProcessBehavior()
        {
            txtProcessLogs.Clear();
            gridProcessInfo.Rows.Clear();
            gridProcessInfo.Columns.Clear();

            gridProcessInfo.Columns.Add("PID", "PID");
            gridProcessInfo.Columns.Add("Name", "Name");
            gridProcessInfo.Columns.Add("User", "User");
            gridProcessInfo.Columns.Add("ParentPID", "Parent PID");
            gridProcessInfo.Columns.Add("StartTime", "Start Time");
            gridProcessInfo.Columns.Add("CPUTime", "CPU Time");
            gridProcessInfo.Columns.Add("MemoryMB", "Memory (MB)");
            gridProcessInfo.Columns.Add("VirtualMemoryMB", "Virtual Mem (MB)");
            gridProcessInfo.Columns.Add("CommandLine", "Command Line");
            gridProcessInfo.Columns.Add("FilePath", "File Path");
            gridProcessInfo.Columns.Add("IsElevated", "Elevated");
            gridProcessInfo.Columns.Add("Responding", "Responding");
            gridProcessInfo.Columns.Add("Error", "Error");

            try
            {
                var processes = ProcessBehaviorMonitor.GetRunningProcesses();
                foreach (var p in processes)
                {
                    gridProcessInfo.Rows.Add(
                        p.PID,
                        p.Name,
                        p.UserName,
                        p.ParentPID,
                        p.StartTime?.ToString("g"),
                        p.CPUTime,
                        p.MemoryMB,
                        p.VirtualMemoryMB,
                        p.CommandLine,
                        p.FilePath,
                        p.IsElevated,
                        p.IsResponding,
                        p.Error
                    );
                }

                txtProcessLogs.AppendText($"Loaded {processes.Count} running processes.\r\n");
            }
            catch (Exception ex)
            {
                txtProcessLogs.AppendText("[ERROR] " + ex.Message);
            }
        }
        private void LoadRdpSessions()
        {
            txtRdpLogs.Clear();
            gridRdpSessions.Rows.Clear();
            gridRdpSessions.Columns.Clear();

            gridRdpSessions.Columns.Add("SessionID", "Session ID");
            gridRdpSessions.Columns.Add("UserName", "User Name");
            gridRdpSessions.Columns.Add("SessionState", "State");
            gridRdpSessions.Columns.Add("LogonTime", "Logon Time");
            gridRdpSessions.Columns.Add("Error", "Error");

            try
            {
                var sessions = RdpSessionMonitor.GetRdpSessions();
                foreach (var s in sessions)
                {
                    gridRdpSessions.Rows.Add(
                        s.SessionID?.ToString() ?? "-",
                        s.UserName,
                        s.SessionState,
                        s.LogonTime?.ToString("g") ?? "-",
                        s.Error
                    );
                }

                txtRdpLogs.AppendText($"Loaded {sessions.Count} RDP sessions.\r\n");
            }
            catch (Exception ex)
            {
                txtRdpLogs.AppendText("[ERROR] " + ex.Message);
            }
        }
        private void LoadRegistryInfo()
        {
            txtRegistryLogs.Clear();
            gridRegistry.Rows.Clear();
            gridRegistry.Columns.Clear();

            gridRegistry.Columns.Add("Hive", "Hive");
            gridRegistry.Columns.Add("Path", "Path");
            gridRegistry.Columns.Add("Name", "Name");
            gridRegistry.Columns.Add("Value", "Value");
            gridRegistry.Columns.Add("Type", "Type");
            gridRegistry.Columns.Add("Error", "Error");

            try
            {
                var entries = RegistryMonitor.GetRegistryInfo();
                foreach (var entry in entries)
                {
                    gridRegistry.Rows.Add(
                        entry.Hive,
                        entry.Path,
                        entry.Name,
                        entry.Value?.ToString(),
                        entry.Type,
                        entry.Error
                    );
                }

                txtRegistryLogs.AppendText($"Loaded {entries.Count} registry entries.\r\n");
            }
            catch (Exception ex)
            {
                txtRegistryLogs.AppendText("[ERROR] " + ex.Message);
            }
        }
        private void LoadSecurityEvents()
        {
            txtSecurityLogs.Clear();
            gridSecurity.Rows.Clear();
            gridSecurity.Columns.Clear();

            gridSecurity.Columns.Add("EventID", "Event ID");
            gridSecurity.Columns.Add("ProviderName", "Provider");
            gridSecurity.Columns.Add("Message", "Message");
            gridSecurity.Columns.Add("TimeCreated", "Time");
            gridSecurity.Columns.Add("Error", "Error");

            try
            {
                var logs = SecurityEventLogTracker.GetCriticalSecurityEvents();
                foreach (var ev in logs)
                {
                    gridSecurity.Rows.Add(
                        ev.EventID,
                        ev.ProviderName,
                        ev.Message,
                        ev.TimeCreated?.ToString("g"),
                        ev.Error
                    );
                }

                txtSecurityLogs.AppendText($"Loaded {logs.Count} security log entries.\r\n");
            }
            catch (Exception ex)
            {
                txtSecurityLogs.AppendText("[ERROR] " + ex.Message);
            }
        }
        private void LoadSystemUptime()
        {
            txtUptimeLogs.Clear();
            gridUptime.Rows.Clear();
            gridUptime.Columns.Clear();

            gridUptime.Columns.Add("LastBoot", "Last Boot Time");
            gridUptime.Columns.Add("UptimeSeconds", "Uptime (s)");
            gridUptime.Columns.Add("UptimeReadable", "Uptime (dd.hh:mm:ss)");
            gridUptime.Columns.Add("Error", "Error");

            try
            {
                var info = SystemUptimeMonitor.GetUptimeInfo();
                gridUptime.Rows.Add(
                    info.LastBootTime?.ToString("g"),
                    info.UptimeSeconds,
                    info.UptimeReadable,
                    info.Error
                );

                txtUptimeLogs.AppendText($"Boot Time: {info.LastBootTime}\r\nUptime: {info.UptimeReadable}\r\n");
            }
            catch (Exception ex)
            {
                txtUptimeLogs.AppendText("[ERROR] " + ex.Message);
            }
        }
        private void LoadUsbDevices()
        {
            txtUsbLogs.Clear();
            gridUsbDevices.Rows.Clear();
            gridUsbDevices.Columns.Clear();

            gridUsbDevices.Columns.Add("DeviceID", "Device ID");
            gridUsbDevices.Columns.Add("PNPDeviceID", "PNP Device ID");
            gridUsbDevices.Columns.Add("Description", "Description");
            gridUsbDevices.Columns.Add("Manufacturer", "Manufacturer");
            gridUsbDevices.Columns.Add("SerialNumber", "Serial Number");
            gridUsbDevices.Columns.Add("Error", "Error");

            try
            {
                var usbDevices = UsbActivityMonitor.GetConnectedUsbDevices();

                foreach (var dev in usbDevices)
                {
                    gridUsbDevices.Rows.Add(
                        dev.DeviceID,
                        dev.PNPDeviceID,
                        dev.Description,
                        dev.Manufacturer,
                        dev.SerialNumber,
                        dev.Error
                    );

                    if (!string.IsNullOrWhiteSpace(dev.Error))
                    {
                        txtUsbLogs.AppendText(dev.Error + "\r\n");
                    }
                }

                txtUsbLogs.AppendText($"Total Devices: {usbDevices.Count}");
            }
            catch (Exception ex)
            {
                txtUsbLogs.AppendText("[ERROR] " + ex.Message);
            }
        }
        private void LoadWindowsUpdates()
        {
            txtUpdateLogs.Clear();
            gridWindowsUpdate.Rows.Clear();
            gridWindowsUpdate.Columns.Clear();

            gridWindowsUpdate.Columns.Add("Title", "Title");
            gridWindowsUpdate.Columns.Add("KB", "KB Article");
            gridWindowsUpdate.Columns.Add("Status", "Install Type");
            gridWindowsUpdate.Columns.Add("Size", "Size (bytes)");

            try
            {
                var updateInfo = WindowsUpdateStatus.GetUpdateInfo();

                if (!string.IsNullOrWhiteSpace(updateInfo.Error))
                {
                    txtUpdateLogs.AppendText(updateInfo.Error + "\r\n");
                    return;
                }

                foreach (var upd in updateInfo.Updates ?? new List<UpdateItem>())
                {
                    gridWindowsUpdate.Rows.Add(upd.Title, upd.KB, upd.Status, upd.Size?.ToString() ?? "N/A");
                }

                txtUpdateLogs.AppendText($"Last Checked: {updateInfo.LastCheckedTime}\r\n");
                txtUpdateLogs.AppendText($"Pending Updates: {updateInfo.PendingUpdates}\r\n");
                txtUpdateLogs.AppendText($"Reboot Required: {updateInfo.RebootRequired}\r\n");
            }
            catch (Exception ex)
            {
                txtUpdateLogs.AppendText("[ERROR] " + ex.Message);
            }
        }
        private void LoadStatusMonitor()
        {
            txtStatusLogs.Clear();
            gridStatusMonitor.Rows.Clear();
            gridStatusMonitor.Columns.Clear();

            gridStatusMonitor.Columns.Add("DeviceID", "Device ID");
            gridStatusMonitor.Columns.Add("Model", "Model");
            gridStatusMonitor.Columns.Add("Status", "Status");
            gridStatusMonitor.Columns.Add("Interface", "Interface");
            gridStatusMonitor.Columns.Add("Media", "Media Type");
            gridStatusMonitor.Columns.Add("Size", "Size (GB)");

            try
            {
                var drives = SmartStatusMonitor.GetDriveHealth();

                foreach (var drive in drives)
                {
                    if (!string.IsNullOrWhiteSpace(drive.Error))
                    {
                        txtStatusLogs.AppendText(drive.Error + "\r\n");
                        continue;
                    }

                    gridStatusMonitor.Rows.Add(
                        drive.DeviceID,
                        drive.Model,
                        drive.Status,
                        drive.InterfaceType,
                        drive.MediaType,
                        (drive.SizeBytes / 1024.0 / 1024.0 / 1024.0).ToString("0.00")
                    );
                }
            }
            catch (Exception ex)
            {
                txtStatusLogs.AppendText("[ERROR] " + ex.Message);
            }
        }



        private void gridCpuGpuInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

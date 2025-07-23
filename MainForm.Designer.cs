namespace MonitoringAgentGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            scrollPanel = new FlowLayoutPanel();
            ((FlowLayoutPanel)scrollPanel).AutoScroll = true;
            ((FlowLayoutPanel)scrollPanel).Dock = DockStyle.Fill;
            ((FlowLayoutPanel)scrollPanel).WrapContents = true;
            ((FlowLayoutPanel)scrollPanel).FlowDirection = FlowDirection.LeftToRight;
            ((FlowLayoutPanel)scrollPanel).Padding = new Padding(10);
            ((FlowLayoutPanel)scrollPanel).AutoSize = true;

            SuspendLayout();

            // Create all controls
            btnStart = new Button(); btnStop = new Button(); btnUpload = new Button(); btnExport = new Button();
            groupBoxDriveInfo = new GroupBox(); gridDriveInfo = new DataGridView(); txtDriveLogs = new TextBox();
            groupBoxCpuGpuInfo = new GroupBox(); gridCpuGpuInfo = new DataGridView(); txtCpuGpuLogs = new TextBox();
            groupBoxBatteryPower = new GroupBox(); gridBatteryPower = new DataGridView(); txtBatteryLogs = new TextBox();
            groupBoxBrowserExtensions = new GroupBox(); gridBrowserExtensions = new DataGridView(); txtBrowserLogs = new TextBox();
            groupBoxAntivirus = new GroupBox(); gridAntivirus = new DataGridView(); txtAntivirusLogs = new TextBox();
            groupBoxDeviceInfo = new GroupBox(); gridDeviceInfo = new DataGridView(); txtDeviceLogs = new TextBox();
            groupBoxFirewall = new GroupBox(); gridFirewall = new DataGridView(); txtFirewallLogs = new TextBox();
            groupBoxSoftwareAudit = new GroupBox(); gridSoftwareAudit = new DataGridView(); txtSoftwareLogs = new TextBox();
            groupBoxDefenderThreats = new GroupBox(); gridDefenderThreats = new DataGridView(); txtDefenderLogs = new TextBox();
            groupBoxEventLogs = new GroupBox(); gridEventLogs = new DataGridView(); txtEventLogs = new TextBox();
            groupBoxHardwareInfo = new GroupBox(); gridHardware = new DataGridView(); txtHardwareLogs = new TextBox();
            groupBoxNetwork = new GroupBox(); gridNetwork = new DataGridView(); txtNetworkLogs = new TextBox();
            groupBoxPatch = new GroupBox(); gridPatchInfo = new DataGridView(); txtPatchLogs = new TextBox();
            groupBoxPortMonitor = new GroupBox(); gridPortMonitor = new DataGridView(); txtPortLogs = new TextBox();
            groupBoxProcessInfo = new GroupBox(); gridProcessInfo = new DataGridView(); txtProcessLogs = new TextBox();
            groupBoxRdpSessions = new GroupBox(); gridRdpSessions = new DataGridView(); txtRdpLogs = new TextBox();
            groupBoxRegistry = new GroupBox(); gridRegistry = new DataGridView(); txtRegistryLogs = new TextBox();
            groupBoxSecurity = new GroupBox(); gridSecurity = new DataGridView(); txtSecurityLogs = new TextBox();
            groupBoxUptime = new GroupBox(); gridUptime = new DataGridView(); txtUptimeLogs = new TextBox();
            groupBoxUsbDevices = new GroupBox(); gridUsbDevices = new DataGridView(); txtUsbLogs = new TextBox();
            groupBoxWindowsUpdate = new GroupBox(); gridWindowsUpdate = new DataGridView(); txtUpdateLogs = new TextBox();
            groupBoxStatusMonitor = new GroupBox(); gridStatusMonitor = new DataGridView(); txtStatusLogs = new TextBox();

            Controls.Add(scrollPanel);

            void SetupGroup(GroupBox group, string title, DataGridView grid, TextBox txt, bool addButtons = false)
            {
                group.Text = title;
                group.Size = new Size(600, 280);
                group.Margin = new Padding(10);

                grid.Dock = DockStyle.Top;
                grid.Height = 150;

                txt.Dock = DockStyle.Fill;
                txt.Multiline = true;
                txt.ScrollBars = ScrollBars.Vertical;

                group.Controls.Add(txt);
                group.Controls.Add(grid);

                if (addButtons)
                {
                    Panel buttonPanel = new Panel();
                    buttonPanel.Dock = DockStyle.Bottom;
                    buttonPanel.Height = 40;

                    btnStart.Text = "Start";
                    btnStart.Size = new Size(80, 30);
                    btnStart.Location = new Point(10, 5);
                    btnStart.Click += btnStart_Click;

                    btnStop.Text = "Stop";
                    btnStop.Size = new Size(80, 30);
                    btnStop.Location = new Point(100, 5);
                    btnStop.Click += btnStop_Click;

                    btnUpload.Text = "Upload";
                    btnUpload.Size = new Size(80, 30);
                    btnUpload.Location = new Point(190, 5);
                    btnUpload.Click += btnUpload_Click;

                    btnExport.Text = "Export";
                    btnExport.Size = new Size(80, 30);
                    btnExport.Location = new Point(280, 5);
                    btnExport.Click += btnExport_Click;

                    buttonPanel.Controls.AddRange(new Control[] { btnStart, btnStop, btnUpload, btnExport });
                    group.Controls.Add(buttonPanel);
                }

                scrollPanel.Controls.Add(group);
            }

            SetupGroup(groupBoxDriveInfo, "Drive Info", gridDriveInfo, txtDriveLogs, true);
            SetupGroup(groupBoxCpuGpuInfo, "CPU & GPU Info", gridCpuGpuInfo, txtCpuGpuLogs);
            SetupGroup(groupBoxBatteryPower, "Battery Power", gridBatteryPower, txtBatteryLogs);
            SetupGroup(groupBoxBrowserExtensions, "Browser Extensions", gridBrowserExtensions, txtBrowserLogs);
            SetupGroup(groupBoxAntivirus, "Antivirus Info", gridAntivirus, txtAntivirusLogs);
            SetupGroup(groupBoxDeviceInfo, "Device Info", gridDeviceInfo, txtDeviceLogs);
            SetupGroup(groupBoxFirewall, "Firewall Info", gridFirewall, txtFirewallLogs);
            SetupGroup(groupBoxSoftwareAudit, "Software Audit", gridSoftwareAudit, txtSoftwareLogs);
            SetupGroup(groupBoxDefenderThreats, "Defender Threat Logs", gridDefenderThreats, txtDefenderLogs);
            SetupGroup(groupBoxEventLogs, "Windows Event Logs", gridEventLogs, txtEventLogs);
            SetupGroup(groupBoxHardwareInfo, "Hardware Info", gridHardware, txtHardwareLogs);
            SetupGroup(groupBoxNetwork, "Network Info", gridNetwork, txtNetworkLogs);
            SetupGroup(groupBoxPatch, "Patch Info", gridPatchInfo, txtPatchLogs);
            SetupGroup(groupBoxPortMonitor, "Open Ports Monitor", gridPortMonitor, txtPortLogs);
            SetupGroup(groupBoxProcessInfo, "Running Processes", gridProcessInfo, txtProcessLogs);
            SetupGroup(groupBoxRdpSessions, "RDP Sessions", gridRdpSessions, txtRdpLogs);
            SetupGroup(groupBoxRegistry, "Registry Audit", gridRegistry, txtRegistryLogs);
            SetupGroup(groupBoxSecurity, "Security Event Logs", gridSecurity, txtSecurityLogs);
            SetupGroup(groupBoxUptime, "System Uptime Info", gridUptime, txtUptimeLogs);
            SetupGroup(groupBoxUsbDevices, "USB Devices", gridUsbDevices, txtUsbLogs);
            SetupGroup(groupBoxWindowsUpdate, "Windows Updates", gridWindowsUpdate, txtUpdateLogs);
            SetupGroup(groupBoxStatusMonitor, "Drive Status Monitor (SMART)", gridStatusMonitor, txtStatusLogs);

            Name = "MainForm";
            Text = "Monitoring Agent";
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1280, 720);
            Load += MainForm_Load;

            ResumeLayout(false);
        }

        #endregion

        private Panel scrollPanel;

        private GroupBox groupBoxDriveInfo;
        private DataGridView gridDriveInfo;
        private TextBox txtDriveLogs;
        private Button btnStart;
        private Button btnStop;
        private Button btnUpload;
        private Button btnExport;

        private GroupBox groupBoxCpuGpuInfo;
        private DataGridView gridCpuGpuInfo;
        private TextBox txtCpuGpuLogs;

        private GroupBox groupBoxBatteryPower;
        private DataGridView gridBatteryPower;
        private TextBox txtBatteryLogs;

        private GroupBox groupBoxBrowserExtensions;
        private DataGridView gridBrowserExtensions;
        private TextBox txtBrowserLogs;

        private GroupBox groupBoxAntivirus;
        private DataGridView gridAntivirus;
        private TextBox txtAntivirusLogs;

        private GroupBox groupBoxDeviceInfo;
        private DataGridView gridDeviceInfo;
        private TextBox txtDeviceLogs;

        private GroupBox groupBoxFirewall;
        private DataGridView gridFirewall;
        private TextBox txtFirewallLogs;

        private GroupBox groupBoxSoftwareAudit;
        private DataGridView gridSoftwareAudit;
        private TextBox txtSoftwareLogs;

        private GroupBox groupBoxDefenderThreats;
        private DataGridView gridDefenderThreats;
        private TextBox txtDefenderLogs;

        private GroupBox groupBoxEventLogs;
        private DataGridView gridEventLogs;
        private TextBox txtEventLogs;

        private GroupBox groupBoxHardwareInfo;
        private DataGridView gridHardware;
        private TextBox txtHardwareLogs;

        private GroupBox groupBoxNetwork;
        private DataGridView gridNetwork;
        private TextBox txtNetworkLogs;

        private GroupBox groupBoxPatch;
        private DataGridView gridPatchInfo;
        private TextBox txtPatchLogs;

        private GroupBox groupBoxPortMonitor;
        private DataGridView gridPortMonitor;
        private TextBox txtPortLogs;

        private GroupBox groupBoxProcessInfo;
        private DataGridView gridProcessInfo;
        private TextBox txtProcessLogs;

        private GroupBox groupBoxRdpSessions;
        private DataGridView gridRdpSessions;
        private TextBox txtRdpLogs;

        private GroupBox groupBoxRegistry;
        private DataGridView gridRegistry;
        private TextBox txtRegistryLogs;

        private GroupBox groupBoxSecurity;
        private DataGridView gridSecurity;
        private TextBox txtSecurityLogs;
       
        private GroupBox groupBoxUptime;
        private DataGridView gridUptime;
        private TextBox txtUptimeLogs;

        private GroupBox groupBoxUsbDevices;
        private DataGridView gridUsbDevices;
        private TextBox txtUsbLogs;

        private GroupBox groupBoxWindowsUpdate;
        private DataGridView gridWindowsUpdate;
        private TextBox txtUpdateLogs;

        private GroupBox groupBoxStatusMonitor;
        private DataGridView gridStatusMonitor;
        private TextBox txtStatusLogs;
    }
}

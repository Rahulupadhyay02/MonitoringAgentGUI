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
            scrollPanel = new Panel();
            groupBoxDriveInfo = new GroupBox();
            gridDriveInfo = new DataGridView();
            txtDriveLogs = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            btnUpload = new Button();
            btnExport = new Button();
            groupBoxCpuGpuInfo = new GroupBox();
            gridCpuGpuInfo = new DataGridView();
            txtCpuGpuLogs = new TextBox();
            groupBoxBatteryPower = new GroupBox();
            gridBatteryPower = new DataGridView();
            txtBatteryLogs = new TextBox();
            groupBoxBrowserExtensions = new GroupBox();
            gridBrowserExtensions = new DataGridView();
            txtBrowserLogs = new TextBox();
            groupBoxAntivirus = new GroupBox();
            gridAntivirus = new DataGridView();
            txtAntivirusLogs = new TextBox();
            groupBoxDeviceInfo = new GroupBox();
            gridDeviceInfo = new DataGridView();
            txtDeviceLogs = new TextBox();
            groupBoxFirewall = new GroupBox();
            gridFirewall = new DataGridView();
            txtFirewallLogs = new TextBox();
            groupBoxSoftwareAudit = new GroupBox();
            gridSoftwareAudit = new DataGridView();
            txtSoftwareLogs = new TextBox();
            groupBoxDefenderThreats = new GroupBox();
            gridDefenderThreats = new DataGridView();
            txtDefenderLogs = new TextBox();
            groupBoxEventLogs = new GroupBox();
            gridEventLogs = new DataGridView();
            txtEventLogs = new TextBox();
            groupBoxHardwareInfo = new GroupBox();
            gridHardware = new DataGridView();
            txtHardwareLogs = new TextBox();
            groupBoxNetwork = new GroupBox();
            gridNetwork = new DataGridView();
            txtNetworkLogs = new TextBox();
            groupBoxPatch = new GroupBox();
            gridPatchInfo = new DataGridView();
            txtPatchLogs = new TextBox();
            groupBoxPortMonitor = new GroupBox();
            gridPortMonitor = new DataGridView();
            txtPortLogs = new TextBox();
            groupBoxProcessInfo = new GroupBox();
            gridProcessInfo = new DataGridView();
            txtProcessLogs = new TextBox();
            groupBoxRdpSessions = new GroupBox();
            gridRdpSessions = new DataGridView();
            txtRdpLogs = new TextBox();
            groupBoxRegistry = new GroupBox();
            gridRegistry = new DataGridView();
            txtRegistryLogs = new TextBox();
            groupBoxSecurity = new GroupBox();
            gridSecurity = new DataGridView();
            txtSecurityLogs = new TextBox();
            groupBoxUptime = new GroupBox();
            gridUptime = new DataGridView();
            txtUptimeLogs = new TextBox();
            groupBoxUsbDevices = new GroupBox();
            gridUsbDevices = new DataGridView();
            txtUsbLogs = new TextBox();
            groupBoxWindowsUpdate = new GroupBox();
            gridWindowsUpdate = new DataGridView();
            txtUpdateLogs = new TextBox();
            groupBoxStatusMonitor = new GroupBox();
            gridStatusMonitor = new DataGridView();
            txtStatusLogs = new TextBox();


            SuspendLayout();


            scrollPanel.AutoScroll = true;
            scrollPanel.Dock = DockStyle.Fill;
            scrollPanel.Location = new Point(0, 0);
            scrollPanel.Name = "scrollPanel";
            scrollPanel.Size = new Size(1200, 800);

            int marginX = 20;
            int marginY = 20;
            int boxWidth = 560;
            int boxHeight = 260;

            GroupBox[] groupBoxes = new GroupBox[]
            {
                groupBoxDriveInfo, groupBoxCpuGpuInfo, groupBoxBatteryPower, groupBoxBrowserExtensions,
                groupBoxAntivirus, groupBoxDeviceInfo, groupBoxFirewall, groupBoxSoftwareAudit,groupBoxDefenderThreats,
                groupBoxEventLogs,groupBoxHardwareInfo,groupBoxNetwork,groupBoxPatch,groupBoxPortMonitor,groupBoxProcessInfo,
                groupBoxRdpSessions,groupBoxRegistry,groupBoxSecurity,groupBoxUptime,groupBoxUsbDevices,groupBoxWindowsUpdate,
                groupBoxStatusMonitor,// 👈 Add this last


            };

            for (int i = 0; i < groupBoxes.Length; i++)
            {
                var group = groupBoxes[i];
                group.Size = new Size(boxWidth, boxHeight);
                group.Location = new Point(
                    marginX + (i % 2) * (boxWidth + marginX),
                    marginY + (i / 2) * (boxHeight + marginY)
                );
                scrollPanel.Controls.Add(group);
            }

            // Drive Info
            groupBoxDriveInfo.Text = "Drive Info";
            groupBoxDriveInfo.Controls.Add(gridDriveInfo);
            groupBoxDriveInfo.Controls.Add(txtDriveLogs);
            groupBoxDriveInfo.Controls.Add(btnStart);
            groupBoxDriveInfo.Controls.Add(btnStop);
            groupBoxDriveInfo.Controls.Add(btnUpload);
            groupBoxDriveInfo.Controls.Add(btnExport);

            gridDriveInfo.Size = new Size(540, 150);
            gridDriveInfo.Location = new Point(10, 20);

            txtDriveLogs.Size = new Size(540, 30);
            txtDriveLogs.Location = new Point(10, 180);

            btnStart.Text = "Start";
            btnStart.Location = new Point(10, 220);
            btnStart.Click += btnStart_Click;

            btnStop.Text = "Stop";
            btnStop.Location = new Point(90, 220);
            btnStop.Click += btnStop_Click;

            btnUpload.Text = "Upload";
            btnUpload.Location = new Point(170, 220);
            btnUpload.Click += btnUpload_Click;

            btnExport.Text = "Export";
            btnExport.Location = new Point(250, 220);
            btnExport.Click += btnExport_Click;

            // Common UI builder function
            void SetupGroup(GroupBox group, string title, DataGridView grid, TextBox txt)
            {
                group.Text = title;
                group.Controls.Add(grid);
                group.Controls.Add(txt);

                grid.Size = new Size(540, 150);
                grid.Location = new Point(10, 20);

                txt.Size = new Size(540, 80);
                txt.Location = new Point(10, 180);
                txt.Multiline = true;
                txt.ScrollBars = ScrollBars.Vertical;
            }

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
            SetupGroup(groupBoxUptime, "System Uptime Info", gridUptime, txtUptimeLogs);
            SetupGroup(groupBoxUsbDevices, "USB Devices", gridUsbDevices, txtUsbLogs);
            SetupGroup(groupBoxWindowsUpdate, "Windows Updates", gridWindowsUpdate, txtUpdateLogs);
            SetupGroup(groupBoxStatusMonitor, "Drive Status Monitor (SMART)", gridStatusMonitor, txtStatusLogs);

            Controls.Add(scrollPanel);
            Name = "MainForm";
            Text = "Monitoring Agent";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;

            ResumeLayout(false);
        }

        #endregion

        private Panel scrollPanel;

        private GroupBox groupBoxDriveInfo;
        private DataGridView gridDriveInfo;
        private TextBox txtDriveLogs;

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

        private Button btnStart;
        private Button btnStop;
        private Button btnUpload;
        private Button btnExport;
    }
}

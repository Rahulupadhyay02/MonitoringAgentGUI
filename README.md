# MonitoringAgentGUI

**MonitoringAgentGUI** is a powerful Windows monitoring and automation tool built with **C# (WinForms)**. It tracks real-time system metrics and hardware health, designed for IT professionals, system administrators, and developers.

---

## 📊 Features Monitored (21 Metrics)

- ✅ CPU & RAM Info
- 💾 Disk Health (SMART Status)
- 🌐 Network Adapter Info (IP, DNS, Gateway)
- 🔐 Security Event Logs (Login Failures, Lockouts)
- 🔧 Installed Windows Patches (via PowerShell)
- 🔁 System Uptime
- 🔌 USB Device Tracking
- 🔒 RDP Sessions Tracker
- 🔥 Running Processes with Behavior (WMI-based)
- 📡 Open Network Ports (TCP/UDP)
- ⚙️ Windows Update Status
- 🔥 Firewall Status
- 📋 Windows Registry Info (Run keys, Defender, RDP)
- 🔎 And many more...

---

## 🖥 Where It Runs

- 💻 **Personal Laptops**
- 🏢 **Office Desktops**
- 🧪 Ideal for **Monitoring Windows EC2 instances** too

---

## 🚀 How to Use

1. Clone or download the repository
2. Build using **Visual Studio (2022 or later)** with **.NET 8**
3. Run the executable or use the provided `.exe` installer (Inno Setup)

---

## 📦 Installer Option

You can install it using the included **Inno Setup script**, or distribute as a portable `.zip`.

---

## 📁 Project Structure

MonitoringAgentGUI/
├── Models/ # C# data models for all metrics
├── Modules/ # All monitoring logic (CPU, RAM, USB, etc.)
├── Program.cs # Entry point
├── MainForm.cs # WinForms GUI logic
├── MainForm.Designer.cs # UI layout
├── .gitignore
├── README.md

---

## 🔮 Future Scope (v2.0 & Beyond)

Planned in the next version:

- 🧩 **BitLocker Drive Encryption Status**
- 🔄 **Pending Reboot Detector**
- 🦠 **Autorun Entries Audit**
- 📁 **File Integrity Checker (Important Files Watch)**
- 🔔 **Email or Webhook Alerts**
- 💡 **Silent Background Mode with Tray Icon**
- 🌐 **Remote Upload to Firebase/Cloud Backend**

---

---

## 🛠 Built With

- [C#](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [.NET 8](https://dotnet.microsoft.com/en-us/)
- [WinForms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
- [WMI](https://learn.microsoft.com/en-us/windows/win32/wmisdk/about-wmi)
- PowerShell (for Patch, Updates)
- Inno Setup (for installer generation)

---

## 📜 License

This project is open-source and free to use for educational or professional purposes.

---

## 🤝 Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you'd like to change.

---

## 🙋‍♂️ Author

👤 **Rahul Upadhyay**  
📧 [rahulupadhyay3640@gmail.com] *(optional)*  
🔗 [https://github.com/Rahulupadhyay02]*

---
🎯 Perfect for IT engineers, system admins, and students seeking real-time visibility and control over Windows systems.

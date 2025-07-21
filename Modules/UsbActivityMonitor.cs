using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class UsbActivityMonitor
    {
        public static List<UsbDeviceInfo> GetConnectedUsbDevices()
        {
            var devices = new List<UsbDeviceInfo>();

            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
                foreach (ManagementObject device in searcher.Get())
                {
                    devices.Add(new UsbDeviceInfo
                    {
                        DeviceID = device["DeviceID"]?.ToString(),
                        PNPDeviceID = device["PNPDeviceID"]?.ToString(),
                        Description = device["Description"]?.ToString(),
                        Manufacturer = device["Manufacturer"]?.ToString(),
                        SerialNumber = device["SerialNumber"]?.ToString() ?? ExtractSerialFromPNP(device["PNPDeviceID"]?.ToString()),
                        Error = null
                    });
                }
            }
            catch (Exception ex)
            {
                devices.Add(new UsbDeviceInfo
                {
                    Error = "[Exception] " + ex.Message
                });
            }

            return devices;
        }

        // Optional: Try to extract serial number from PNPDeviceID
        private static string ExtractSerialFromPNP(string pnp)
        {
            if (string.IsNullOrWhiteSpace(pnp)) return null;
            var parts = pnp.Split('\\');
            return parts.Length > 2 ? parts[2] : null;
        }
    }
}

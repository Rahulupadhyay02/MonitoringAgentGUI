using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonitoringAgent.Models;
using System.Management;

namespace MonitoringAgent.Modules
{
    public static class SmartStatusMonitor
    {
        public static List<DriveHealthInfo> GetDriveHealth()
        {
            var drives = new List<DriveHealthInfo>();

            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject drive in searcher.Get())
                {
                    try
                    {
                        drives.Add(new DriveHealthInfo
                        {
                            DeviceID = drive["DeviceID"]?.ToString(),
                            Model = drive["Model"]?.ToString(),
                            Status = drive["Status"]?.ToString(), // "OK", "Pred Fail", etc.
                            InterfaceType = drive["InterfaceType"]?.ToString(),
                            MediaType = drive["MediaType"]?.ToString(),
                            SizeBytes = Convert.ToInt64(drive["Size"]),
                            Error = null
                        });
                    }
                    catch (Exception inner)
                    {
                        drives.Add(new DriveHealthInfo
                        {
                            DeviceID = drive["DeviceID"]?.ToString(),
                            Error = "[Drive Error] " + inner.Message
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                drives.Add(new DriveHealthInfo
                {
                    Error = "[Exception] " + ex.Message
                });
            }

            return drives;
        }
    }
}


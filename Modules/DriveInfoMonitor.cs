using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MonitoringAgent.Models;

namespace MonitoringAgent.Modules
{
    public static class DriveInfoMonitor
    {
        public static List<DriveData> GetDriveInfo()
        {
            var drives = new List<DriveData>();
            foreach (var drive in DriveInfo.GetDrives())
            {
                try
                {
                    if (drive.IsReady)
                    {
                        drives.Add(new DriveData
                        {
                            Name = drive.Name,
                            DriveType = drive.DriveType.ToString(),
                            Format = drive.DriveFormat,
                            TotalSizeGB = drive.TotalSize / (1024 * 1024 * 1024),
                            FreeSpaceGB = drive.TotalFreeSpace / (1024 * 1024 * 1024),
                            VolumeLabel = drive.VolumeLabel
                        });
                    }
                }
                catch (Exception ex)
                {
                    drives.Add(new DriveData { Name = drive.Name, Error = ex.Message });
                }
            }

            return drives;
        }
    }
}


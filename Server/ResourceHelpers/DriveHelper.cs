using System;
using ServerInfo.Types;
using System.IO;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using ServerInfo.API.Controllers;

namespace ServerInfo.API.ResourceHelpers
{
    public static class DriveHelper
    {
        public static IEnumerable<Drive> GetDrives()
        {
            DriveInfo[] arr = DriveInfo.GetDrives();
            List<Drive> drives = new List<Drive>();
            foreach(DriveInfo i in arr)
            {
                Drive drive = new Drive
                {
                    AvailableFreeSpace = i.AvailableFreeSpace,
                    DriveFormat = i.DriveFormat,
                    DriveType = i.DriveType,
                    IsReady = i.IsReady,
                    Name = i.Name,
                    RootDirectory = i.RootDirectory.FullName,
                    TotalFreeSpace = i.TotalFreeSpace,
                    TotalSize = i.TotalSize,
                    VolumeLabel = i.VolumeLabel
                };
                drives.Add(drive);
            }
            return drives;
        }
    }
}

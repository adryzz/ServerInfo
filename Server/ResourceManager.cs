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

namespace ServerInfo.API
{
    public static class ResourceManager
    {
        public static MemoryInfo GetMemoryInfo()
        {
            MemoryInfo info = new MemoryInfo();
            string[] lines = File.ReadAllLines("/proc/meminfo");
            foreach(string line in lines)
            {
                string property = Regex.Match(line, @"^[a-zA-Z]+").Value;
                string valuestring = Regex.Match(line, @"\d+").Value;
                ulong value = ulong.Parse(valuestring) * 1024;
                switch(property)
                {
                    case "MemTotal":
                        info.MemTotal = value;
                        break;
                    case "MemFree":
                        info.MemFree = value;
                        break;
                    case "MemAvailable":
                        info.MemAvailable = value;
                        break;
                    case "Buffers":
                        info.Buffers = value;
                        break;
                    case "Cached":
                        info.Cached = value;
                        break;
                    case "SwapCached":
                        info.SwapCached = value;
                        break;
                    case "Active":
                        info.Active = value;
                        break;
                    case "Inactive":
                        info.Inactive = value;
                        break;
                    case "SwapTotal":
                        info.SwapTotal = value;
                        break;
                    case "SwapFree":
                        info.SwapFree = value;
                        break;
                    case "Dirty":
                        info.Dirty = value;
                        break;
                    case "Mapped":
                        info.Mapped = value;
                        break;
                    case "Shmem":
                        info.Shmem = value;
                        break;
                }
            }
            return info;
        }

        public static UptimeInfo GetUptimeInfo()
        {
            UptimeInfo info = new UptimeInfo();
            info.Time = DateTime.Now;
            string text = File.ReadAllText("/proc/uptime");
            string value = Regex.Match(text, @"^[\x21-\x7E]+").Value;
            info.Uptime = TimeSpan.FromSeconds(double.Parse(value));
            info.StartupTime = info.Time.Subtract(info.Uptime);
            return info;
        }

        public static IEnumerable<AdvancedNetworkInterface> GetNetworkInfo()
        {
            //get basic data
            NetworkInterface[] anics = NetworkInterface.GetAllNetworkInterfaces();

            AdvancedNetworkInterface[] nics = new AdvancedNetworkInterface[anics.Length];
            for(int i = 0; i < anics.Length; i++)
            {
                nics[i] = new AdvancedNetworkInterface(anics[i]);
            }

            //get total data sent/received
            string[] lines = File.ReadAllLines("/proc/net/dev");

            foreach(string line in lines)
            {
                GroupCollection groups = Regex.Match(line, @"(?<name>\S*):\s+(?<receive>\d+)\s+(?<stuff>\d+\s+){7}(?<sent>\d+)").Groups;
                for(int i = 0; i < nics.Length; i++)
                {
                    if (groups["name"].Value == nics[i].Id)
                    {
                        nics[i].SentBytes = ulong.Parse(groups["sent"].Value);
                        nics[i].ReceivedBytes = ulong.Parse(groups["receive"].Value);
                    }
                }
            }

            Thread.Sleep(100);

            for(int i = 0; i < nics.Length; i++)
            {
                ulong tx = ulong.Parse(File.ReadAllText($"/sys/class/net/{nics[i].Id}/statistics/tx_bytes"));
                ulong rx = ulong.Parse(File.ReadAllText($"/sys/class/net/{nics[i].Id}/statistics/rx_bytes"));
                nics[i].TransmitSpeed = (long)(tx - nics[i].SentBytes) * 10 * 8;
                nics[i].ReceiveSpeed = (long)(rx - nics[i].ReceivedBytes) * 10 * 8;
            }
            return nics;
        }

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

        public static IEnumerable<Disk> GetDisks()
        {
            string[] lines = File.ReadAllLines("/proc/partitions");
            List<Disk> disks = new List<Disk>();
            List<string> matches = new List<string>();
            foreach(string line in lines)
            {
                Match match = Regex.Match(line, @"\w+$");
                if (!string.IsNullOrWhiteSpace(match.Value))
                {
                    matches.Add(match.Value);
                }
            }

            Regex isPartition = new Regex(@"\d$");
            for(int i = 1; i < matches.Count; i++)
            {
                string match = matches[i];
                if (!isPartition.IsMatch(match))//if it is a drive (does NOT work with NVMe drives  )
                {
                    Disk disk = new Disk();
                    disk.Name = match;
                    disk.Temperature = null;
                    disk.Partitions = new string[0];
                    disks.Add(disk);
                }
                else 
                {
                    Disk disk = disks[disks.Count-1];
                    string[] partitions = disk.Partitions;
                    disk.Partitions = new string[disk.Partitions.Length+1];
                    partitions.CopyTo(disk.Partitions, 0);
                    disk.Partitions[disk.Partitions.Length-1] = match;
                    disks[disks.Count-1] = disk;
                }
            }
            return disks;
        }
    }
}

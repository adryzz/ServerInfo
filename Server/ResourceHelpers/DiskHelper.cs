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
    public static class DiskHelper
    {
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

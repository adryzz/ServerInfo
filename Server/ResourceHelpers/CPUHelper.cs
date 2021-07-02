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
    public static class CPUHelper
    {
        public static CPUInfo GetCPUInfo()
        {
            CPUInfo info = new CPUInfo();

            string stat0 = File.ReadAllText("/proc/stat");
            MatchCollection cpulines0 = Regex.Matches(stat0, "^[cpu].*", RegexOptions.Multiline);
            Thread.Sleep(100);
            string stat1 = File.ReadAllText("/proc/stat");
            MatchCollection cpulines1 = Regex.Matches(stat1, "^[cpu].*", RegexOptions.Multiline);

            info.AverageUsagePercentage = GetCPUPercentage(cpulines0[0].Value, cpulines1[0].Value);
            
            string text = File.ReadAllText("/proc/cpuinfo");
            string[] cpus = text.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

            List<CoreInfo> cores = new List<CoreInfo>();
            foreach(string cpu in cpus)
            {
                MatchCollection collection = Regex.Matches(cpu, @"\:\s(.*)", RegexOptions.Multiline);
                CoreInfo i = new CoreInfo();
                i.Index = int.Parse(collection[0].Groups[1].Value);
                i.Vendor = collection[1].Groups[1].Value;
                i.Name = collection[4].Groups[1].Value;
                i.Frequency = double.Parse(collection[7].Groups[1].Value);
                cores.Add(i);
            }
            info.CPUs = cores.ToArray();
            return info;
        }

        private static long GetCPUPercentage(string line)
        {
            MatchCollection matches = Regex.Matches(line, @"\d+");
            long total = 0;
            foreach(Match m in matches)
            {
                total += long.Parse(m.Value);
            }
            return total;
        }
    }
}

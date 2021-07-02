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
using System.Globalization;

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
            info.AverageUsagePercentage = GetCPUPercentage(cpulines0[0].Value, cpulines1[0].Value);
            for(int i = 0; i < cores.Count; i++)
            {
                CoreInfo ci = cores[i];
                ci.UsagePercentage = GetCPUPercentage(cpulines0[i+1].Value, cpulines1[i+1].Value);
                cores[i] = ci;
            }
            info.CPUs = cores.ToArray();
            return info;
        }

        private static double GetCPUPercentage(string line0, string line1)
        {
            ulong[] s0 = GetCPUStates(line0);
            ulong[] s1 = GetCPUStates(line1);

            ulong active = GetActiveTime(s1) - GetActiveTime(s0);
            ulong idle = GetIdleTime(s1) - GetIdleTime(s0);
            ulong total = active + idle;
            double percentage = 100f * (double)active / (double)total;
            return percentage;
        }

        private static ulong GetActiveTime(ulong[] states)
        {
            ulong active = 0;
            active += states[(int)CPUStates.USER];
            active += states[(int)CPUStates.NICE];
            active += states[(int)CPUStates.SYSTEM];
            active += states[(int)CPUStates.IRQ];
            active += states[(int)CPUStates.SOFTIRQ];
            active += states[(int)CPUStates.STEAL];
            active += states[(int)CPUStates.GUEST];
            active += states[(int)CPUStates.GUEST_NICE];
            return active;
        }

        private static ulong GetIdleTime(ulong[] states)
        {
            ulong idle = 0;
            idle += states[(int)CPUStates.IDLE];
            idle += states[(int)CPUStates.IOWAIT];
            return idle;
        }

        private static ulong[] GetCPUStates(string line)
        {
            MatchCollection matches = Regex.Matches(line, @"\d+");
            ulong[] states = new ulong[10];
            for(int i = 0; i < 10; i++)
            {
                states[i] = ulong.Parse(matches[i].Value);
            }
            return states;
        }

        private enum CPUStates
        {
	        USER,
	        NICE,
	        SYSTEM,
	        IDLE,
	        IOWAIT,
	        IRQ,
	        SOFTIRQ,
	        STEAL,
	        GUEST,
	        GUEST_NICE
        }
    }
}

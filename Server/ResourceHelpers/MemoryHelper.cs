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
    public static class MemoryHelper
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
    }
}

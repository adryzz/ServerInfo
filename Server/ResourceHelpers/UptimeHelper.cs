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
    public static class UptimeHelper
    {
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
    }
}

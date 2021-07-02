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
    public static class NetworkHelper
    {
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
    }
}

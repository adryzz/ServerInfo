using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace ServerInfoAPI.Types
{
    public struct UptimeInfo
    {
        public DateTime Time { get; set; }
        public DateTime StartupTime { get; set; }
        public TimeSpan Uptime { get; set; }
    }
}

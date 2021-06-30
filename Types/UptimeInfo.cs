using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace ServerInfoAPI.Types
{
    public struct UptimeInfo
    {
        public DateTime Time;
        public DateTime StartupTime;
        public TimeSpan Uptime;
    }
}

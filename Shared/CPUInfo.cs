using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace ServerInfo.Types
{
    public struct CPUInfo
    {
        public double AverageUsagePercentage { get; set; }
        public int? AverageTemperature { get; set; }
        public CoreInfo[] CPUs { get; set; }
    }
}

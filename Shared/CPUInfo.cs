using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace ServerInfo.Types
{
    public struct CPUInfo
    {
        public int Index { get; set; }
        public string Vendor { get; set; }
        public int Frequency { get; set; }
        public int? Temperature { get; set; }
        public int UsagePercentage { get; set; }
    }
}

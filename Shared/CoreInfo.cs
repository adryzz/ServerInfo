using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace ServerInfo.Types
{
    public struct CoreInfo
    {
        public int Index { get; set; }
        public string Vendor { get; set; }
        public string Name { get; set; }
        public double Frequency { get; set; }
        public int? Temperature { get; set; }
        public double UsagePercentage { get; set; }
    }
}

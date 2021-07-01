using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace ServerInfo.Types
{
    public struct Disk
    {
        public string Name { get; set; }
        public string[] Partitions { get; set; }

        public int IOPS { get; set; }

        public int Latency { get; set; }
        public int? Temperature { get; set; }
    }
}

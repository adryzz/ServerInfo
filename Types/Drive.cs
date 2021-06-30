using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace ServerInfoAPI.Types
{
    public struct Drive
    {
        public long AvailableFreeSpace;
        public string DriveFormat;
        public DriveType DriveType;
        public bool IsReady;
        public string Name;
        public string RootDirectory;
        public long TotalFreeSpace;
        public long TotalSize;
        public string VolumeLabel;
    }
}

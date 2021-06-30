using System;

namespace ServerInfoAPI.Types
{
    public struct MemoryInfo
    {
        public ulong MemTotal { get; set; }
        public ulong MemFree { get; set; }
        public ulong MemAvailable { get; set; }
        public ulong Buffers { get; set; }
        public ulong Cached { get; set; }
        public ulong SwapCached { get; set; }
        public ulong Active { get; set; }
        public ulong Inactive { get; set; }
        public ulong SwapTotal { get; set; }
        public ulong SwapFree { get; set; }
        public ulong Dirty { get; set; }
        public ulong Mapped { get; set; }
        public ulong Shmem { get; set; }
    }
}

using System;

namespace ServerInfoAPI.Types
{
    public struct MemoryInfo
    {
        public ulong MemTotal;
        public ulong MemFree;
        public ulong MemAvailable;
        public ulong Buffers;
        public ulong Cached;
        public ulong SwapCached;
        public ulong Active;
        public ulong Inactive;
        public ulong SwapTotal;
        public ulong SwapFree;
        public ulong Dirty;
        public ulong Mapped;
        public ulong Shmem;
    }
}

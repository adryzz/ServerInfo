using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Buffers;

namespace ServerInfoAPI.Types
{
    public struct AdvancedNetworkInterface
    {
        public AdvancedNetworkInterface(NetworkInterface nic)
        {
            Id = nic.Id;
            Name = nic.Name;
            Description = nic.Description;
            OperationalStatus = nic.OperationalStatus;
            Speed = nic.Speed;
            NetworkInterfaceType = nic.NetworkInterfaceType;
            IsReceiveOnly = nic.IsReceiveOnly;
            SupportsMulticast = nic.SupportsMulticast;
            SentBytes = 0;
            ReceivedBytes = 0;
            TransmitSpeed = 0;
            ReceiveSpeed = 0;
        }
        public string Id;
        public string Name;
        public string Description;
        public OperationalStatus OperationalStatus;
        public long Speed;
        public NetworkInterfaceType NetworkInterfaceType;
        public bool IsReceiveOnly;
        public bool SupportsMulticast;
        public ulong SentBytes;
        public ulong ReceivedBytes;
        public long TransmitSpeed;
        public long ReceiveSpeed;
    }
}

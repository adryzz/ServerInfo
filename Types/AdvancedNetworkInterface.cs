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
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public OperationalStatus OperationalStatus { get; set; }
        public long Speed { get; set; }
        public NetworkInterfaceType NetworkInterfaceType { get; set; }
        public bool IsReceiveOnly { get; set; }
        public bool SupportsMulticast { get; set; }
        public ulong SentBytes { get; set; }
        public ulong ReceivedBytes { get; set; }
        public long TransmitSpeed { get; set; }
        public long ReceiveSpeed { get; set; }
    }
}

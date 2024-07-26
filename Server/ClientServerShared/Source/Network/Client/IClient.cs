using System;
using System.Net;

namespace Network.Client
{
    public interface IClient
    {
        event Action<byte[]> DataReceived;
        ConnectionStatus Status { get; }
        
        void Stop();
        void Start();

        void Send(byte[] data, DeliveryType type);
    }
}
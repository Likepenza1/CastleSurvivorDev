using System;
using System.Net;

namespace Network.Server
{
    public interface IServer
    {
        event Action<IPEndPoint, byte[]> DataReceived;
        event Action<IPEndPoint> ClientConnected;
        event Action<IPEndPoint> ClientDisconnected;
        
        public void Stop();
        public void Start();

        public void Send(IPEndPoint target, byte[] data, DeliveryType deliveryType);
    }
}
using System;
using System.Net;
using Core.Awaiters.Time;
using LiteNetLib;
using Network.Client;

namespace Network.Server
{
    public class UdpServer : IServer
    {
        public event Action<IPEndPoint, byte[]>? DataReceived;
        public event Action<IPEndPoint>? ClientConnected;
        public event Action<IPEndPoint>? ClientDisconnected;

        private readonly string _connectionKey;
        private readonly int _port;
        private readonly int _maxConnectionsCount;
        private readonly EventBasedNetListener _listener;
        private readonly NetManager _server;
        private UdpPollEventsSystem _system;
        
        public UdpServer(int port, string connectionKey, int maxConnectionsCount = 10000)
        {
            _connectionKey = connectionKey;
            _port = port;
            _maxConnectionsCount = maxConnectionsCount;
            _listener = new EventBasedNetListener();
            _server = new NetManager(_listener);
        }
        
        public void Stop()
        {
            _listener.ConnectionRequestEvent -= OnConnectionRequest;
            _listener.PeerConnectedEvent -= OnPeerConnected;
            _listener.NetworkReceiveEvent -= OnReceiveEvent;
            _listener.PeerDisconnectedEvent -= OnPeerDisconnected;

            AwaiterScheduler.Systems.Remove(_system);
            _server.Stop();
        }

        public void Start()
        {
            _listener.ConnectionRequestEvent += OnConnectionRequest;
            _listener.PeerConnectedEvent += OnPeerConnected;
            _listener.NetworkReceiveEvent += OnReceiveEvent;
            _listener.PeerDisconnectedEvent += OnPeerDisconnected;

            _system = new UdpPollEventsSystem(_server);
            AwaiterScheduler.Systems.Add(_system);
            
            _server.Start(_port);
        }

        public void Send(IPEndPoint target, byte[] data, DeliveryType deliveryType)
        {
            var peer = (NetPeer)target;
            var method = UdpDeliveryHelper.GetDeliveryMethod(deliveryType);
            peer.Send(data, method);
        }

        private void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            ClientDisconnected?.Invoke(peer);
        }

        private void OnReceiveEvent(NetPeer peer, NetPacketReader reader, byte channel, DeliveryMethod deliveryMethod)
        {
            var data = new byte[reader.UserDataSize];
            reader.GetBytes(data, 0, reader.UserDataSize);
            reader.Recycle();
            
            DataReceived?.Invoke(peer, data);
        }

        private void OnPeerConnected(NetPeer peer)
        {
            ClientConnected?.Invoke(peer);
            Console.WriteLine($"Connected {peer}");
        }

        private void OnConnectionRequest(ConnectionRequest request)
        {
            if (_server.ConnectedPeersCount < _maxConnectionsCount)
            {
                request.AcceptIfKey(_connectionKey);
            }
            else
            {
                request.Reject();
            }
        }
    }
}
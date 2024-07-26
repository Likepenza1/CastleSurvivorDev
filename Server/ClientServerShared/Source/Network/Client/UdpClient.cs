using System;
using System.Net;
using Core.Awaiters.Time;
using LiteNetLib;

namespace Network.Client
{
    public class UdpClient : IClient
    {
        public event Action<byte[]> DataReceived;
        public event Action Connected;

        private readonly string _host;
        private readonly int _port;
        private readonly string _connectionKey;
        
        private readonly EventBasedNetListener _listener;
        private readonly NetManager _client;
        private NetPeer _server;
        private UdpPollEventsSystem _system;


        public UdpClient(string host, int port, string connectionKey)
        {
            _host = host;
            _port = port;
            _connectionKey = connectionKey;
            _listener = new EventBasedNetListener();
            _client = new NetManager(_listener);
        }

        public IPEndPoint ServerIp => _server;

        public ConnectionStatus Status => GetStatus();

        private ConnectionStatus GetStatus()
        {
            if (_server == null)
            {
                return ConnectionStatus.Connecting;
            }

            var status = _server.ConnectionState switch
            {
                ConnectionState.Connected => ConnectionStatus.Connected,
                ConnectionState.ShutdownRequested => ConnectionStatus.Unknown,
                ConnectionState.Disconnected => ConnectionStatus.Disconnected,
                ConnectionState.EndPointChange => ConnectionStatus.Unknown,
                ConnectionState.Any => ConnectionStatus.Unknown,
                _ => ConnectionStatus.Unknown
            };

            return status;
        }

        public void Stop()
        {
            _listener.NetworkReceiveEvent -= OnNetworkReceiveEvent;
            _listener.ConnectionRequestEvent -= OnConnectionRequest;
            _listener.PeerConnectedEvent -= OnPeerConnected;
            
            AwaiterScheduler.Systems.Remove(_system);
            
            _client.DisconnectAll();
            _client.Stop();
        }

        public void Start()
        {
            _listener.NetworkReceiveEvent += OnNetworkReceiveEvent;
            _listener.ConnectionRequestEvent += OnConnectionRequest;
            _listener.PeerConnectedEvent += OnPeerConnected;

            _client.Start();
            _server = _client.Connect(_host, _port, _connectionKey);

            _system = new UdpPollEventsSystem(_client);
            AwaiterScheduler.Systems.Add(_system);
        }

        public void Send(byte[] data, DeliveryType type)
        {
            _server.Send(data, UdpDeliveryHelper.GetDeliveryMethod(type));
        }

        private void OnConnectionRequest(ConnectionRequest request)
        {
            request.AcceptIfKey(_connectionKey);
        }

        private void OnPeerConnected(NetPeer peer)
        {
            Connected?.Invoke();
        }

        private void OnNetworkReceiveEvent(NetPeer peer, NetPacketReader reader, byte channel, DeliveryMethod deliverymethod)
        {
            var data = new byte[reader.UserDataSize];
            reader.GetBytes(data, 0, reader.UserDataSize);
            
            DataReceived?.Invoke(data);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Network.Server
{
    public class WebSocketsGameServer : IServer
    {
        private readonly string _connectionKey;
        public event Action<IPEndPoint, byte[]> DataReceived;
        public event Action<IPEndPoint> ClientConnected;
        public event Action<IPEndPoint> ClientDisconnected;
        
        public class GameService : WebSocketBehavior
        {
            public static event Action<string, IPEndPoint> Open;
            public static event Action<string, IPEndPoint> Closed;
            public static event Action<IPEndPoint, byte[]> DataReceived;

            protected override void OnOpen()
            {
                Open?.Invoke(ID, UserEndPoint);
            }

            protected override void OnClose(CloseEventArgs e)
            {
                base.OnClose(e);
                
                Closed?.Invoke(ID, UserEndPoint);
            }

            protected override void OnError(ErrorEventArgs e)
            {
                base.OnError(e);
                Console.WriteLine($"error on {UserEndPoint} : {e.Message}");
            }

            protected override void OnMessage(MessageEventArgs e)
            {
                var data = e.RawData;
                DataReceived?.Invoke(UserEndPoint, data);
            }
        }

        private readonly Dictionary<IPEndPoint, string> _connections = new();
        private readonly WebSocketServer _webServer;
        private WebSocketServiceHost _service;

        public WebSocketsGameServer(int port, string connectionKey, bool isSecure = true, X509Certificate2 certificate = default)
        {
            _connectionKey = connectionKey;
            var ip = "0.0.0.0";
            var protocol = isSecure ? "wss" : "ws";
            _webServer = new WebSocketServer($"{protocol}://{ip}:{port}");

            if (isSecure)
            {
                _webServer.SslConfiguration.ServerCertificate = certificate;
            }
        }

        public void Stop()
        {
            GameService.Open -= OnOpen;
            GameService.Closed -= OnClose;
            GameService.DataReceived -= OnDataReceived;
            
            _webServer.Stop();
        }

        public void Start()
        {
            _webServer.AddWebSocketService<GameService>($"/{_connectionKey}");
            _service = _webServer.WebSocketServices[$"/{_connectionKey}"];

            GameService.Open += OnOpen;
            GameService.Closed += OnClose;
            GameService.DataReceived += OnDataReceived;

            _webServer.Start();
        }

        public void Send(IPEndPoint target, byte[] data, DeliveryType deliveryType)
        {
            if (deliveryType == DeliveryType.Unreliable)
            {
                Console.WriteLine($"[ERROR] Cannot send data by {deliveryType} method using HTTP. Sending by {DeliveryType.Reliable} instead");
            }

            var socket = GetSocket(target);
            socket.Send(data);
        }

        private WebSocket GetSocket(string id)
        {
            return _service.Sessions[id].WebSocket;
        }
        
        private WebSocket GetSocket(IPEndPoint ip)
        {
            return GetSocket(_connections[ip]);
        }

        private void OnDataReceived(IPEndPoint peer, byte[] data)
        {
            DataReceived?.Invoke(peer, data);
        }

        private void OnClose(string id, IPEndPoint peer)
        {
            ClientDisconnected?.Invoke(peer);
            _connections.Remove(peer);
            Console.WriteLine($"{peer} disconnected");
        }

        private void OnOpen(string id, IPEndPoint peer)
        {
            if (_connections.ContainsKey(peer))
            {
                ClientDisconnected?.Invoke(peer);
                _connections.Remove(peer);
            }
            
            _connections.Add(peer, id);
            Console.WriteLine($"{peer} connected");
            ClientConnected?.Invoke(peer);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Core.Controllers;
using Network.Handlers;
using Network.Messages;
using Network.Serialization;
using Network.Server;

namespace Network.Processor
{
    public class NetworkServerProcessor : IController
    {
        public event Action<IPEndPoint> Disconnected; 
        public event Action<IPEndPoint> Connected; 

        private readonly BaseHandlerFactory _handlerFactory;
        private readonly BaseSerializer _serializer;
        private readonly IServer _server;
        
        private readonly HashSet<IPEndPoint> _connections = new();

        public NetworkServerProcessor(BaseHandlerFactory handlerFactory, BaseSerializer serializer, IServer server)
        {
            _handlerFactory = handlerFactory;
            _serializer = serializer;
            _server = server;
        }
        

        public void Deactivate()
        {
            _server.Stop();
            _server.DataReceived -= OnDataReceived;
            _server.ClientConnected -= OnClientConnected;
            _server.ClientDisconnected -= OnClientDisconnected;
        }

        public void Activate()
        {
            _serializer.Init();
            _handlerFactory.Init();
            _server.Start();
            
            Console.WriteLine($"Server started, server type = {_server.GetType()}");
            
            _server.DataReceived += OnDataReceived;
            _server.ClientConnected += OnClientConnected;
            _server.ClientDisconnected += OnClientDisconnected;
        }

        private void OnClientDisconnected(IPEndPoint ip)
        {
            Disconnected?.Invoke(ip);
            _connections.Remove(ip);
        }

        private void OnClientConnected(IPEndPoint ip)
        {
            Connected?.Invoke(ip);
            _connections.Add(ip);
        }

        private void OnDataReceived(IPEndPoint ip, byte[] data)
        {
            try
            {
                var message = _serializer.Deserialize<IMessage>(data);

                if (_handlerFactory.TryGetHandler(message, out var handler))
                {
                    handler.TryExecute(message, ip);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public void Send(IPEndPoint peer, IMessage message, DeliveryType deliveryType = DeliveryType.Reliable)
        {
            var data = _serializer.Serialize(message);
            _server.Send(peer, data, deliveryType);
        }
        
        public void Broadcast(IMessage message, DeliveryType deliveryType)
        {
            foreach (var peer in _connections)
            {
                var data = _serializer.Serialize(message);
                Console.WriteLine($"send data, size = {data.Length}");
                _server.Send(peer, data, deliveryType);
            }
        }
        
        public void Broadcast(string text, DeliveryType deliveryType)
        {
            foreach (var peer in _connections)
            {
                var data = Encoding.UTF8.GetBytes(text);
                _server.Send(peer, data, deliveryType);
            }
        }
    }
}
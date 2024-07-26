using System;
using Core.Controllers;
using Network.Client;
using Network.Handlers;
using Network.Messages;
using Network.Serialization;

namespace Network.Processor
{
    public class NetworkClientProcessor : IController
    {
        private readonly BaseHandlerFactory _handlerFactory;
        private readonly BaseSerializer _serializer;
        private readonly DataReceiver _data = new();
        private readonly IClient _client;
        private readonly bool _processImmediately;

        public NetworkClientProcessor(BaseHandlerFactory handlerFactory, BaseSerializer serializer, IClient client, bool processImmediately = false)
        {
            _handlerFactory = handlerFactory;
            _serializer = serializer;
            _client = client;
            _processImmediately = processImmediately;
        }
        
        public void Deactivate()
        {
            _client.Stop();
            _client.DataReceived -= OnDataReceived;
        }

        public void Activate()
        {
            _serializer.Init();
            _handlerFactory.Init();
            _client.Start();
            
            _client.DataReceived += OnDataReceived;
        }

        public void Send(IMessage message, DeliveryType deliveryType = DeliveryType.Reliable)
        {
            var data = _serializer.Serialize(message);
            _client.Send(data, deliveryType);
        }

        private void OnDataReceived(byte[] data)
        {
            _data.Put(data);

            if (_processImmediately)
            {
                ProcessReceivedData();
            }
        }

        public void ProcessReceivedData()
        {
            if (!_data.HasUnprocessed)
            {
                return;
            }

            var data = _data.Get();
            
            #if UNITY_EDITOR || UNITY_WEBGL
            // UnityEngine.Debug.Log($"data size = {data.Length}");
            #endif
            
            try
            {
                var message = _serializer.Deserialize<IMessage>(data);
                
                if (_handlerFactory.TryGetHandler(message, out var handler))
                {
                    handler.TryExecute(message, default);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
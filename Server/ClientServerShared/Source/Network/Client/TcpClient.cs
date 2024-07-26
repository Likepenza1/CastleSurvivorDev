using System;
using System.Net.Sockets;
using Core.Awaiters.Time;
using Core.Systems;

namespace Network.Client
{
    public class TcpClient : SystemBase, IClient
    {
        private readonly string _host;
        private readonly int _port;
        private readonly System.Net.Sockets.TcpClient _client;
        private NetworkStream _stream;
        private ConnectionStatus _status = ConnectionStatus.Disconnected;
        private readonly byte[] _buffer;

        public event Action<byte[]> DataReceived;

        public ConnectionStatus Status => _status;

        public TcpClient(string host, int port, string appKey, int bufferSize = 1024)
        {
            _host = host;
            _port = port;
            _client = new System.Net.Sockets.TcpClient();
            _buffer = new byte[bufferSize];
        }
        public void Stop()
        {
            if (_client.Connected)
            {
                _stream.Close();
                _client.Close();
                _status = ConnectionStatus.Disconnected;
            }
        }

        public void Start()
        {
            _client.Connect(_host, _port);
            _stream = _client.GetStream();
            _status = ConnectionStatus.Connected;
            BeginReading();

            AwaiterScheduler.Systems.Add(this);
        }

        public void Send(byte[] data, DeliveryType type)
        {
            if (_client.Connected)
            {
                try
                {
                    _stream.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    #if UNITY_WEBGL
                    UnityEngine.Debug.Log($"[ERROR] error on send {ex}");
                    #endif
                    // ignored
                }
            }
        }

        public override void Update(float deltaTime)
        {
            // Debug.Log("update");
        }

        private void BeginReading()
        {
            _stream.BeginRead(_buffer, 0, _buffer.Length, Callback, _buffer);
        }

        private void Callback(IAsyncResult ar)
        {
            byte[] buffer = (byte[])ar.AsyncState;
            int bytesRead;
            bytesRead = _stream.EndRead(ar);
            
            if (bytesRead > 0)
            {
                byte[] receivedData = new byte[bytesRead];
                Array.Copy(buffer, receivedData, bytesRead);
                DataReceived?.Invoke(receivedData);
            }
            
            BeginReading();
        }
    }
}
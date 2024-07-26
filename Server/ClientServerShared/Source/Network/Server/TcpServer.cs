using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Server
{
    public class TcpServer : IServer
    {
        private readonly TcpListener _listener;
        private bool _isRunning;
        private readonly Dictionary<IPEndPoint, NetworkStream> _clientStreams;

        public event Action<IPEndPoint, byte[]> DataReceived;
        public event Action<IPEndPoint> ClientConnected;
        public event Action<IPEndPoint> ClientDisconnected;

        public TcpServer(int port, string appKey)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _clientStreams = new Dictionary<IPEndPoint, NetworkStream>();
        }

        public async void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _listener.Start();
                await WaitForClientsAsync();
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                _listener.Stop();
            }
        }

        public void Send(IPEndPoint target, byte[] data, DeliveryType deliveryType)
        {
            if (_clientStreams.ContainsKey(target))
            {
                try
                {
                    _clientStreams[target].Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine($"Error sending data to {target}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Client {target} is not connected.");
            }
        }

        private async Task WaitForClientsAsync()
        {
            while (_isRunning)
            {
                try
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    _ = HandleClientAsync(client);
                }
                catch (SocketException)
                {
                    // SocketException will be thrown when listener is stopped
                    // Ignore and exit the loop
                    break;
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            NetworkStream stream = client.GetStream();
            _clientStreams.Add(clientEndPoint, stream);
            
            ClientConnected?.Invoke(clientEndPoint);
            Console.WriteLine($"{clientEndPoint} connected");

            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    byte[] receivedData = new byte[bytesRead];
                    Array.Copy(buffer, receivedData, bytesRead);
                    DataReceived?.Invoke(clientEndPoint, receivedData);
                }
            }
            catch (Exception)
            {
                // Client disconnected
            }
            finally
            {
                _clientStreams.Remove(clientEndPoint);
                client.Close();
                ClientDisconnected?.Invoke(clientEndPoint);
            }
        }
    }
}

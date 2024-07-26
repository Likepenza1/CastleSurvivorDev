using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Network.Server
{
    public class HttpServer : IServer
    {
        private readonly int _port;
        private readonly string _connectionKey;
        private HttpListener _listener;
        public event Action<IPEndPoint, byte[]>? DataReceived;
        public event Action<IPEndPoint>? ClientConnected;
        public event Action<IPEndPoint>? ClientDisconnected;
        
        public HttpServer(int port, string connectionKey)
        {
            _port = port;
            _connectionKey = connectionKey;
            _listener = new HttpListener();
        }
        
        public void Stop()
        {
        }

        public async void Start()
        {
            _listener.Prefixes.Add("http://localhost:" + _port + "/");
            _listener.Start();
            
            while (true)
            {
                // Асинхронное ожидание входящего запроса
                var context = await _listener.GetContextAsync();
                await Task.Run(() => HandleRequest(context));
            }
            
        }

        private async Task HandleRequest(HttpListenerContext context)
        {
            // var request = context.Request;
            // var response = context.Response;
            //
            // if (request.HttpMethod == "POST")
            // {
            //     using (MemoryStream ms = new MemoryStream())
            //     {
            //         var endPoint = request.RemoteEndPoint;
            //         
            //         await request.InputStream.CopyToAsync(ms);
            //         var requestData = ms.ToArray();
            //         
            //         DataReceived?.Invoke(endPoint, requestData);
            //
            //         var responseBytes = ;
            //
            //         response.ContentLength64 = responseBytes.Length;
            //         using (Stream output = response.OutputStream)
            //         {
            //             await output.WriteAsync(responseBytes, 0, responseBytes.Length);
            //         }
            //     }
            // }
        }

        public void Send(IPEndPoint target, byte[] data, DeliveryType deliveryType)
        {
        }
    }
    
    public class HttpServer2 : IServer
    {
        private readonly string _connectionKey;
        public event Action<IPEndPoint, byte[]>? DataReceived;
        public event Action<IPEndPoint>? ClientConnected;
        public event Action<IPEndPoint>? ClientDisconnected;

        private readonly Dictionary<IPEndPoint, byte[]> _connections = new();

        private readonly WebSocketSharp.Server.HttpServer _server;

        public HttpServer2(int port, string connectionKey)
        {
            _connectionKey = connectionKey;
            _server = new(port);
        }

        public void Stop()
        {
            _server.OnPost -= OnPost;
        }

        public void Start()
        {
            _server.Start();
            _server.OnPost += OnPost;
        }
        
        private void OnPost(object? sender, HttpRequestEventArgs e)
        {
            var peer = e.Request.RemoteEndPoint;
            
            var buffer = new byte[1024];
            var bytesRead = e.Request.InputStream.Read(buffer);
            var receivedData = new byte[bytesRead];
            Array.Copy(buffer, receivedData, bytesRead);
            DataReceived?.Invoke(peer, receivedData);

            // if (_connections.ContainsKey(peer))
            // {
            //
            //
            //     if (_connections[peer] != null)
            //     {
            //         e.Response.OutputStream.Write(_connections[peer]);
            //         _connections[peer] = null;
            //     }
            // }
            // else
            // {
            //     var reader = new StreamReader(e.Request.InputStream);
            //     var requestData = reader.ReadToEnd();
            //
            //     if (requestData == _connectionKey)
            //     {
            //         _connections.Add(peer, null);
            //         ClientConnected?.Invoke(peer);
            //     }
            // }
        }

        public void Send(IPEndPoint target, byte[] data, DeliveryType deliveryType)
        {
            if (!_connections.ContainsKey(target))
            {
                return;
            }

            _connections[target] = data;
        }
    }
}
using System;
using System.Net;
using Core.Controllers;
using Server.ServerCore.Startup;
using Server.ServerLogic.Players;

namespace Server.ServerCore
{
    public class PlayerRemoveController : IController
    {
        private readonly ServerContext _context;
        private readonly PlayersCollection _playersCollection;

        public PlayerRemoveController(ServerContext context, PlayersCollection playersCollection)
        {
            _context = context;
            _playersCollection = playersCollection;
        }

        public void Deactivate()
        {
            _context.Network.Disconnected -= OnDisconnected;
        }

        public void Activate()
        {
            _context.Network.Disconnected += OnDisconnected;
        }

        private void OnDisconnected(IPEndPoint ip)
        {
            if (_playersCollection.Contains(ip))
            {
                var player = _playersCollection[ip];
                Console.WriteLine($"player removed {player.Id}");
                _playersCollection.Remove(player);
            }
        }
    }
}
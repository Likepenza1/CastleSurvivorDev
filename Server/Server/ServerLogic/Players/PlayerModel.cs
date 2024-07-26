using System.Net;
using Core.Fields;
using Game.Player;

namespace Server.ServerLogic.Players
{
    public class PlayerModel
    {
        public string Id => Data.Id.Value;
        public readonly Field<bool> Initialized = new();
        
        public IPEndPoint Ip;
        public readonly PlayerData Data;

        public PlayerModel(IPEndPoint ip, PlayerData data)
        {
            Ip = ip;
            Data = data;
        }
    }
}
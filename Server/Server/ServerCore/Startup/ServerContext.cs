using Descriptions;
using Network.Processor;
using Server.ServerCore.Serialization;
using Server.ServerLogic.Players;

namespace Server.ServerCore.Startup
{
    public class ServerContext
    {
        public PlayersCollection Players { get; } = new();
        public NetworkServerProcessor Network { get; set; }
        public MessagePackServerSerializer Serializer { get; } = new();
        public ServerEngine Engine { get; } = new();
        public GameRules GameRules { get; set; }
    }
}
using System.Net;
using Network.Messages;
using Server.ServerCore.Startup;
using Server.ServerLogic.Players;

namespace Server.ServerLogic
{
    public abstract class PlayerInitializedHandler<TMessage> : BaseServerHandler<TMessage>
        where TMessage : IMessage
    {

        public sealed override void Execute(ServerContext context, TMessage message, IPEndPoint ip)
        {
            if (!context.Players.Contains(ip))
            {
                SendLog("missing player", ip);
                return;
            }
            
            var player = context.Players[ip];

            if (!player.Initialized.Value)
            {
                SendLog("not initialized", ip);
                return;
            }

            Execute(context, message, player);
        }

        public abstract void Execute(ServerContext context, TMessage message, PlayerModel player);


        protected void SendLog(string message, PlayerModel player) => SendLog(message, player.Ip);
    }
}
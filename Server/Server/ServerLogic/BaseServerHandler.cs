using System.Net;
using Messages;
using Network;
using Network.Handlers;
using Network.Messages;
using Server.ServerCore.Startup;

namespace Server.ServerLogic
{
    public abstract class BaseServerHandler<TMessage> : BaseMessageHandler<TMessage> 
        where TMessage : IMessage
    {

        public sealed override void Execute(TMessage message, IPEndPoint ip)
        {
            var context = ContextGetter.Context;
            
            Execute(context, message, ip);
        }

        public abstract void Execute(ServerContext context, TMessage message, IPEndPoint ip);

        public void SendLog(string message, IPEndPoint ip)
        {
            var context = ContextGetter.Context;
            var log = new LogMessage();
            log.Text = message;
            
            context.Network.Send(ip, log);
        }
    }
}
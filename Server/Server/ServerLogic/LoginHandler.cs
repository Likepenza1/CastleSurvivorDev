using System;
using System.Net;
using Messages;
using Server.ServerCore.Startup;

namespace Server.ServerLogic
{
    public class LoginHandler : BaseServerHandler<LoginMessage>
    {
        public override void Execute(ServerContext context, LoginMessage message, IPEndPoint ip)
        {
            var id = message.Id;
            var key = message.AuthKey;

            if (context.Players.Contains(ip))
            {
                SendLog("Already connected", ip);
                return;
            }
            
            if (context.Players.Contains(id))
            {
                SendLog($"already connected with id {id}", ip);
                return;
            }

            var player = context.Players.Add(id, ip);
        }
    }
}
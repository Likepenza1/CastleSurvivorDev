using System;
using System.Net;
using Messages;
using Network.Handlers;

namespace Server.ServerLogic
{
    public class LogHandler : BaseMessageHandler<LogMessage>
    {
        public override void Execute(LogMessage message, IPEndPoint ip)
        {
            var text = $"[LOG_MESSAGE] {ip} : {message.Text}";
            Console.WriteLine(text);
        }
    }
}
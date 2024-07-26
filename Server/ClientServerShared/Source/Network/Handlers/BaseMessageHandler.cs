using System.Net;
using Network.Messages;

namespace Network.Handlers
{
    public abstract class BaseMessageHandler<T> : IMessageHandler
    where T : IMessage
    {
        public abstract void Execute(T message, IPEndPoint ip);

        public void TryExecute(IMessage message, IPEndPoint ip)
        {
            Execute((T)message, ip);
        }
    }
}
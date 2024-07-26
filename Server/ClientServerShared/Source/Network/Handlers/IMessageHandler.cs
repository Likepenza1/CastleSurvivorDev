using System.Net;
using Network.Messages;

namespace Network.Handlers
{
    public interface IMessageHandler
    {
        public void TryExecute(IMessage message, IPEndPoint ip);
    }
}
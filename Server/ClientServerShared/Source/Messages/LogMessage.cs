using MessagePack;
using Network.Messages;

namespace Messages
{
    [MessagePackObject]
    public class LogMessage : IMessage
    {
        [Key(0)]
        public string Text;
    }
}
using MessagePack;
using Network.Messages;

namespace Messages
{
    [MessagePackObject]
    public class LoginMessage : IMessage
    {
        [Key(0)]
        public string Id;

        [Key(1)]
        public string AuthKey;
    }

}
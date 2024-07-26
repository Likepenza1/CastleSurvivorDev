using DataTypes;
using MessagePack;
using Network.Messages;

namespace Messages
{
    [MessagePackObject]
    public class PlayerDiffMessage : IMessage
    {
        [Key(0)]
        public IDataDiff Data;
    }
}
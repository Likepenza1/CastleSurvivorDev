using MessagePack;
using Network.Messages;

namespace Messages
{
    [MessagePackObject]
    public class FinishStageMessage : IMessage
    {
        [Key(0)]
        public int CompleteWaveIndex;
    }
}
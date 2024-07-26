using Descriptions.Rewards;
using MessagePack;
using Network.Messages;

namespace Messages
{
    [MessagePackObject]
    public class GetRewardCheatMessage : IMessage
    {
        [Key(0)]
        public IReward Reward;
    }
}
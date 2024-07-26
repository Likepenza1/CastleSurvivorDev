using Game.Player.Upgrades;
using MessagePack;
using Messages;

namespace Network.Messages
{
    [Union(0, typeof(TestMessage))]
    [Union(1, typeof(LogMessage))]
    [Union(2, typeof(LoginMessage))]
    [Union(3, typeof(LoginConfirmMessage))]
    [Union(4, typeof(PlayerDiffMessage))]
    [Union(5, typeof(GetRewardCheatMessage))]
    [Union(6, typeof(FinishStageMessage))]
    [Union(7, typeof(UpgradeMessage))]
    public interface IMessage
    {
    }
}
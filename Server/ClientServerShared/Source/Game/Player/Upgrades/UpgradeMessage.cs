using MessagePack;
using Network.Messages;

namespace Game.Player.Upgrades
{
    [MessagePackObject]
    public class UpgradeMessage : IMessage
    {
        [Key(0)]
        public string Id;
        
        [Key(1)]
        public int CurrentLevel;
    }
}
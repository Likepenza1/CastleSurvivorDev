using Game.Player;
using MessagePack;

namespace Descriptions.Rewards
{
    [Union(0, typeof(ResourceReward))]
    [Union(1, typeof(CompositeReward))]
    public interface IReward
    { 
        void Award(PlayerData player);
        bool Validate(GameRules gameRules, PlayerData player);
    }
}
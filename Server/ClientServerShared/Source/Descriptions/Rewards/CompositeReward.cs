using System.Linq;
using Game.Player;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Rewards
{
    [MessagePackObject(true)]
    public class CompositeReward : IReward
    {
        [ShowInInspector]
        public IReward[] Rewards;

        public void Award(PlayerData user)
        {
            foreach (var reward in Rewards)
            {
                reward.Award(user);
            }
        }

        public bool Validate(GameRules gameRules, PlayerData user)
        {
            return Rewards != null && Rewards.All(item => item != null && item.Validate(gameRules, user));
        }
    }
}
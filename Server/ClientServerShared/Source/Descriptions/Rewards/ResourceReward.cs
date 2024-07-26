using System;
using Descriptions.Types;
using Game.Player;
using MessagePack;
using Sirenix.OdinInspector;
using WebSocketSharp;

namespace Descriptions.Rewards
{
    [MessagePackObject(true)]
    public class ResourceReward : IReward
    {
        [ShowInInspector]
        public ResourceReference Resource;

        [ShowInInspector]
        public long Amount;
        
        public void Award(PlayerData player)
        {
            var data = player.Resources[Resource.Id];
            data.Value = Math.Clamp(data.Value + Amount, 0, long.MaxValue);
        }

        public bool Validate(GameRules gameRules, PlayerData player)
        {
            if (Resource.Id.IsNullOrEmpty())
            {
                return false;
            }

            if (!gameRules.Resources.ContainsKey(Resource.Id))
            {
                return false;
            }

            return true;
        }
    }
}
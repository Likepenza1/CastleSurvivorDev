using Messages;
using Server.ServerCore.Startup;
using Server.ServerLogic.Players;

namespace Server.ServerLogic
{
    public class GetRewardCheatHandler : PlayerInitializedHandler<GetRewardCheatMessage>
    {
        public override void Execute(ServerContext context, GetRewardCheatMessage message, PlayerModel player)
        {
            var gameRules = context.GameRules;
            
            if (!message.Reward.Validate(gameRules, player.Data))
            {
                SendLog("reward is not valid", player);
                return;
            }
            
            message.Reward.Award(player.Data);
        }
    }
}
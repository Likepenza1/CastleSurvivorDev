using System;
using Messages;
using Server.ServerCore.Startup;
using Server.ServerLogic.Players;

namespace Server.ServerLogic
{
    public class FinishStageHandler : PlayerInitializedHandler<FinishStageMessage>
    {
        public override void Execute(ServerContext context, FinishStageMessage message, PlayerModel player)
        {
            var stageIndex = player.Data.StageLevel.Value;
            var waveIndex = message.CompleteWaveIndex;
            var stageId = context.GameRules.StagesSequence.Stages[stageIndex].Id;
            var stageDescription = context.GameRules.Stages[stageId];
            var wasLastWave = stageDescription.Waves.Length - 1 == waveIndex;

            if (wasLastWave)
            {
                var maxStageIndex = context.GameRules.StagesSequence.Stages.Length - 1;
                player.Data.StageLevel.Value = Math.Clamp(player.Data.StageLevel.Value + 1, 0, maxStageIndex);

                var reward = stageDescription.CompleteReward;
                reward?.Award(player.Data);
            }

            player.Data.PlayedPreviously.Value = true;
        }
    }
}
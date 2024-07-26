using Game.Player.Upgrades;
using Server.ServerCore.Startup;
using Server.ServerLogic.Players;
using WebSocketSharp;

namespace Server.ServerLogic
{
    public class UpgradeHandler : PlayerInitializedHandler<UpgradeMessage>
    {
        public override void Execute(ServerContext context, UpgradeMessage message, PlayerModel player)
        {
            var upgradeId = message.Id;

            if (upgradeId.IsNullOrEmpty())
            {
                SendLog("Incorrect id", player);
                return;
            }

            if (!context.GameRules.Upgrades.TryGetValue(upgradeId, out var upgradeDescription))
            {
                SendLog("Wrong upgrade id", player);
                return;
            }

            var upgradeData = player.Data.Upgrades[upgradeId];

            if (upgradeDescription.MaxLevel <= upgradeData.Value)
            {
                SendLog("Max level exceeded", player);
                return;
            }

            if (upgradeData.Value != message.CurrentLevel)
            {
                SendLog("Already bought", player);
                return;
            }

            var levelDescription = upgradeDescription.Levels[upgradeData.Value];
            var resourceData = player.Data.Resources[levelDescription.Resource.Id];

            if (resourceData.Value < levelDescription.UpgradePrice)
            {
                SendLog("Not enough resource", player);
                return;
            }

            resourceData.Value -= levelDescription.UpgradePrice;
            upgradeData.Value++;
        }
    }
}
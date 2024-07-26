using System;
using System.Collections.Generic;
using Game.Player;
using Game.Player.Upgrades;
using Messages;
using Network.Handlers;

namespace Server.ServerLogic
{
    public class ServerHandlersFactory : BaseHandlerFactory
    {
        public override IEnumerable<(Type type, IMessageHandler handler)> CreateHandlers()
        {
            yield return (typeof(LogMessage), new LogHandler());
            yield return (typeof(LoginMessage), new LoginHandler());
            yield return (typeof(GetRewardCheatMessage), new GetRewardCheatHandler());
            yield return (typeof(FinishStageMessage), new FinishStageHandler());
            yield return (typeof(UpgradeMessage), new UpgradeHandler());
        }
    }
}
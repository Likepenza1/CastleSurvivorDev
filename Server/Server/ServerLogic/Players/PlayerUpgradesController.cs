using Core.Controllers;
using DataTypes.Fields;
using Server.ServerCore.Startup;

namespace Server.ServerLogic.Players
{
    public class PlayerUpgradesController : IController
    {
        private readonly ServerContext _context;
        private readonly PlayerModel _model;

        public PlayerUpgradesController(ServerContext context, PlayerModel model)
        {
            _context = context;
            _model = model;
        }

        public void Deactivate()
        {
        }

        public void Activate()
        {
            foreach (var (id, description) in _context.GameRules.Upgrades)
            {
                if (!_model.Data.Upgrades.ContainsId(id))
                {
                    var resource = new IntDataField();
                    _model.Data.Upgrades.Add(id, resource);
                }
            }
        }
    }
}
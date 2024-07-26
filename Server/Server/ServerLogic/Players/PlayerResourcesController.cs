using Core.Controllers;
using DataTypes.Fields;
using Server.ServerCore.Startup;

namespace Server.ServerLogic.Players
{
    public class PlayerResourcesController : IController
    {
        private readonly ServerContext _context;
        private readonly PlayerModel _model;

        public PlayerResourcesController(ServerContext context, PlayerModel model)
        {
            _context = context;
            _model = model;
        }

        public void Deactivate()
        {
        }

        public void Activate()
        {
            foreach (var (id, description) in _context.GameRules.Resources)
            {
                if (!_model.Data.Resources.ContainsId(id))
                {
                    var resource = new LongDataField();
                    resource.Value = description.StartValue;
                    
                    _model.Data.Resources.Add(id, resource);
                }
            }
        }
    }
}
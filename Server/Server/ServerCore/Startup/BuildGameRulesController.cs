using Core.Controllers;
using Descriptions;

namespace Server.ServerCore.Startup
{
    public class BuildGameRulesController : IController
    {
        private readonly ServerContext _context;

        public BuildGameRulesController(ServerContext context)
        {
            _context = context;
        }

        public void Deactivate()
        {
        }

        public void Activate()
        {
            _context.Serializer.Init();
            _context.GameRules = new GameRules();
            _context.GameRules.Build();
        }
    }
}
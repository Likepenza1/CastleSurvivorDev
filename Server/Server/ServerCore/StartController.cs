using System.Collections.Generic;
using Core.Controllers;
using Server.ServerCore.Startup;
using Server.ServerLogic.Players;

namespace Server.ServerCore
{
    public class StartController : BaseStartController
    {
        private readonly ServerContext _context;

        public StartController(ServerContext context) : base(context)
        {
            _context = context;
        }

        protected override IEnumerable<IController> CreateServerControllers()
        {
            yield return new PlayerRemoveController(_context, _context.Players);
            yield return new PlayerCollectionController(_context, _context.Players);
        }
    }
}
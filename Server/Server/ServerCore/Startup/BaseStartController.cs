using System.Collections.Generic;
using Core.Controllers;

namespace Server.ServerCore.Startup
{
    public abstract class BaseStartController : ControllersGroupController
    {
        private readonly ServerContext _context;

        public BaseStartController(ServerContext context)
        {
            _context = context;
        }

        protected override IEnumerable<IController> CreateControllers()
        {
            ContextGetter.Init(_context);
            
            yield return new StartEngineController(_context.Engine);
            yield return new InitializeAwaitController(_context.Engine);
            yield return new BuildGameRulesController(_context);
            yield return new StartServerProcessorController(_context);

            foreach (var controller in CreateServerControllers())
            {
                yield return controller;
            }
        }

        protected abstract IEnumerable<IController> CreateServerControllers();
    }
}
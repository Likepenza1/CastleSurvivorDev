using Core.Awaiters.Time;
using Core.Controllers;

namespace Server.ServerCore.Startup
{
    public class InitializeAwaitController : IController
    {
        private readonly ServerEngine _engine;

        public InitializeAwaitController(ServerEngine engine)
        {
            _engine = engine;

        }
        
        public void Deactivate()
        {
        }

        public void Activate()
        {
            AwaiterScheduler.Initialize(_engine.Systems);
        }
    }
}
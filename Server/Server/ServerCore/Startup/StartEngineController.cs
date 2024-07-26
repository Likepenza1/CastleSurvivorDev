using Core.Controllers;

namespace Server.ServerCore.Startup
{
    public class StartEngineController : IController
    {
        private readonly ServerEngine _engine;

        public StartEngineController(ServerEngine engine)
        {
            _engine = engine;
        }

        public void Deactivate()
        {
        }

        public void Activate()
        {
            _engine.Start(200);
        }
    }
}
using System;
using System.Collections.Generic;
using Core.Controllers;
using Server.ServerCore.Save;
using Server.ServerCore.Startup;

namespace Server.ServerLogic.Players
{
    public class PlayerController : ControllersGroupController
    {
        private readonly ServerContext _context;
        private readonly PlayerModel _model;

        public PlayerController(ServerContext context, PlayerModel model)
        {
            _context = context;
            _model = model;
        }

        protected override IEnumerable<IController> CreateControllers()
        {
            Console.WriteLine($"player added {_model.Id}");

            yield return new PlayerResourcesController(_context, _model);
            yield return new PlayerUpgradesController(_context, _model);
            yield return new PlayerSaveController(_context, _model);
            yield return new AddSystemController(_context.Engine.Systems, new SendPlayerDiffSystem(_context, _model));
            yield return new AddSystemController(_context.Engine.Systems, new TestPlayerSystem(_context, _model));
        }
    }
}
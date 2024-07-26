using Core.Controllers;
using Server.ServerCore.Startup;
using Server.ServerLogic.Base;

namespace Server.ServerLogic.Players
{
    public class PlayerCollectionController : BaseCollectionController<PlayerModel>
    {
        private readonly ServerContext _context;
        private readonly PlayersCollection _collection;

        public PlayerCollectionController(ServerContext context, PlayersCollection collection) : base(collection)
        {
            _context = context;
            _collection = collection;
        }

        protected override IController CreateController(PlayerModel model)
        {
            return new PlayerController(_context, model);
        }
    }

}
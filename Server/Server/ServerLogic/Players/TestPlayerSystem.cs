using Core.Systems;
using CoreExtension;
using Server.ServerCore.Startup;
using UnityEngine;

namespace Server.ServerLogic.Players
{
    public class TestPlayerSystem : TickSystemBase
    {
        private readonly ServerContext _context;
        private readonly PlayerModel _model;

        public TestPlayerSystem(ServerContext context, PlayerModel model) : base(1000)
        {
            _context = context;
            _model = model;
        }

        public override void Tick()
        {
            var description = _context.GameRules.AppearanceDescription;
            var appearance = _model.Data.Appearance;
            
            appearance.HairColor.Value = Vector3.one;
            appearance.Gender.Value = RandomExtensions.GetBool();
            appearance.HairIndex.Value = RandomExtensions.InRange(0, description.HairsCount);
        }
    }
}
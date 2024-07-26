using Core.Systems;
using Messages;
using Server.ServerCore.Startup;

namespace Server.ServerLogic.Players
{
    public class SendPlayerDiffSystem : TickSystemBase
    {
        private readonly ServerContext _context;
        private readonly PlayerModel _model;

        public SendPlayerDiffSystem(ServerContext context, PlayerModel model) : base(100)
        {
            _context = context;
            _model = model;
        }
        
        public override void Tick()
        {
            if (!_model.Initialized.Value)
            {
                return;
            }
            
            if (!_model.Data.IsDirty)
            {
                return;
            }

            Send();
        }

        private void Send()
        {
            var message = new PlayerDiffMessage()
            {
                Data = _model.Data.GetDiff()
            };

            _context.Network.Send(_model.Ip, message);
            _model.Data.ClearChanged();
        }
    }
}
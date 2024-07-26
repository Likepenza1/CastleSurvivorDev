using Game.Player;
using Messages;
using Server.ServerCore.Startup;
using Server.ServerLogic.Players;

namespace Server.ServerCore.Save
{
    public class PlayerSaveController : BaseDataSaveController<PlayerData>
    {
        private readonly ServerContext _context;
        private readonly PlayerModel _playerModel;

        public PlayerSaveController(ServerContext context, PlayerModel playerModel) : base(playerModel.Id, playerModel.Data, 25f, 45f)
        {
            _context = context;
            _playerModel = playerModel;
        }

        protected override void OnCompleteLoad()
        {
            var confirm = new LoginConfirmMessage();
            confirm.PlayerData = _playerModel.Data.GetWhole();
            confirm.GameRules = _context.GameRules;

            _context.Network.Send(_playerModel.Ip, confirm);
            _playerModel.Data.ClearChanged();

            _playerModel.Initialized.Value = true;
        }

        protected override void BeforeSave()
        {
            var message = new LogMessage();
            message.Text = $"[{_playerModel.Id}] Save - start";
            _context.Network.Send(_playerModel.Ip, message);
        }

        protected override void OnSave()
        {
            var message = new LogMessage();
            message.Text = $"[{_playerModel.Id}] Save - complete";
            _context.Network.Send(_playerModel.Ip, message);
        }
    }
}
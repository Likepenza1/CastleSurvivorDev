using System.Collections.Generic;
using System.Net;
using Core.Fields;
using Game.Player;
using Server.ServerLogic.Base;

namespace Server.ServerLogic.Players
{
    public class PlayersCollection : IActiveCollection<PlayerModel>
    {
        public TriggerField<PlayerModel> Added { get; } = new();
        public TriggerField<PlayerModel> Removed { get; } = new();

        private readonly Dictionary<IPEndPoint, PlayerModel> _ipToPlayers = new();
        private readonly Dictionary<string, PlayerModel> _idToPlayers = new();

        public PlayerModel Add(string id, IPEndPoint ip)
        {
            var data = new PlayerData();
            data.Id.Value = id;

            var model = new PlayerModel(ip, data);

            _ipToPlayers[ip] = model;
            _idToPlayers[id] = model;
            
            Added.Call(model);
            
            return model;
        }

        public PlayerModel this[IPEndPoint ip] => _ipToPlayers[ip];
        public PlayerModel this[string id] => _idToPlayers[id];
        
        public void Remove(PlayerModel model)
        {
            if (!_idToPlayers.ContainsKey(model.Id))
            {
                return;
            }
            
            if (!_ipToPlayers.ContainsKey(model.Ip))
            {
                return;
            }

            _ipToPlayers.Remove(model.Ip);
            _idToPlayers.Remove(model.Id);
            
            Removed.Call(model);
        }

        public bool Contains(IPEndPoint ip) => _ipToPlayers.ContainsKey(ip);
        public bool Contains(string id) => _idToPlayers.ContainsKey(id);

        public IEnumerable<PlayerModel> GetAll()
        {
            return _idToPlayers.Values;
        }
    }
}
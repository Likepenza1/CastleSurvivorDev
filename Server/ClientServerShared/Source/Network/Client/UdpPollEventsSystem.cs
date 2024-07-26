using Core.Systems;
using LiteNetLib;

namespace Network.Client
{
    public class UdpPollEventsSystem : SystemBase
    {
        private readonly NetManager _manager;

        public UdpPollEventsSystem(NetManager manager)
        {
            _manager = manager;
        }

        public override void Update(float deltaTime)
        {
            _manager.PollEvents();
        }
    }
}
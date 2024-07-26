using MessagePack;
using MessagePack.Resolvers;
using Network.Serialization;

namespace Server.ServerCore.Serialization
{
    public class MessagePackServerSerializer : BaseSerializer
    {
        public override void Init()
        {
            var resolver = CompositeResolver.Create(
                ServerResolver.Instance,
                MessagePack.Unity.UnityResolver.Instance,
                StandardResolver.Instance
            );
            
            var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);
            MessagePackSerializer.DefaultOptions = options;
        }

        public override T Deserialize<T>(byte[] data) => MessagePackSerializer.Deserialize<T>(data);

        public override byte[] Serialize<T>(T value) => MessagePackSerializer.Serialize(value);
    }
}
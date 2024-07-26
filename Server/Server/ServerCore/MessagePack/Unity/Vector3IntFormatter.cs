using System;
// ReSharper disable CheckNamespace

namespace MessagePack.Unity
{
    public sealed class Vector3IntFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::UnityEngine.Vector3Int>
    {
        public void Serialize(ref MessagePackWriter writer, global::UnityEngine.Vector3Int value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(3);
            writer.WriteInt32(value.x);
            writer.WriteInt32(value.y);
            writer.WriteInt32(value.z);
        }
        public global::UnityEngine.Vector3Int Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                throw new InvalidOperationException("typecode is null, struct not supported");
            }
            var length = reader.ReadArrayHeader();
            var __x__ = default(int);
            var __y__ = default(int);
            var __z__ = default(int);
            for (int i = 0; i < length; i++)
            {
                var key = i;
                switch (key)
                {
                    case 0:
                        __x__ = reader.ReadInt32();
                        break;
                    case 1:
                        __y__ = reader.ReadInt32();
                        break;
                    case 2:
                        __z__ = reader.ReadInt32();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::UnityEngine.Vector3Int(__x__, __y__, __z__);
            ____result.x = __x__;
            ____result.y = __y__;
            ____result.z = __z__;
            return ____result;
        }
    }
}
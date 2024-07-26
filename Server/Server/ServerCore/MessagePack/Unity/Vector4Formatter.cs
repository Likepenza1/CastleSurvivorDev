using System;
// ReSharper disable CheckNamespace

namespace MessagePack.Unity
{
    public sealed class Vector4Formatter : global::MessagePack.Formatters.IMessagePackFormatter<global::UnityEngine.Vector4>
    {
        public void Serialize(ref MessagePackWriter writer, global::UnityEngine.Vector4 value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(4);
            writer.Write(value.x);
            writer.Write(value.y);
            writer.Write(value.z);
            writer.Write(value.w);
        }

        public global::UnityEngine.Vector4 Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                throw new InvalidOperationException("typecode is null, struct not supported");
            }

            var length = reader.ReadArrayHeader();
            var x = default(float);
            var y = default(float);
            var z = default(float);
            var w = default(float);
            for (int i = 0; i < length; i++)
            {
                var key = i;
                switch (key)
                {
                    case 0:
                        x = reader.ReadSingle();
                        break;
                    case 1:
                        y = reader.ReadSingle();
                        break;
                    case 2:
                        z = reader.ReadSingle();
                        break;
                    case 3:
                        w = reader.ReadSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var result = new global::UnityEngine.Vector4(x, y, z, w);
            return result;
        }
    }
}
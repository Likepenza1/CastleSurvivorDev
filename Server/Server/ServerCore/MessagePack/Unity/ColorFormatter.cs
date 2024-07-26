using System;
// ReSharper disable CheckNamespace

namespace MessagePack.Unity
{
    public sealed class ColorFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::UnityEngine.Color>
    {
        public void Serialize(ref MessagePackWriter writer, global::UnityEngine.Color value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(4);
            writer.Write(value.r);
            writer.Write(value.g);
            writer.Write(value.b);
            writer.Write(value.a);
        }

        public global::UnityEngine.Color Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                throw new InvalidOperationException("typecode is null, struct not supported");
            }

            var length = reader.ReadArrayHeader();
            var r = default(float);
            var g = default(float);
            var b = default(float);
            var a = default(float);
            for (int i = 0; i < length; i++)
            {
                var key = i;
                switch (key)
                {
                    case 0:
                        r = reader.ReadSingle();
                        break;
                    case 1:
                        g = reader.ReadSingle();
                        break;
                    case 2:
                        b = reader.ReadSingle();
                        break;
                    case 3:
                        a = reader.ReadSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var result = new global::UnityEngine.Color(r, g, b, a);
            return result;
        }
    }
}
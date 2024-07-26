using System;
// ReSharper disable CheckNamespace

namespace MessagePack.Unity
{
    public sealed class RectFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::UnityEngine.Rect>
    {
        public void Serialize(ref MessagePackWriter writer, global::UnityEngine.Rect value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(4);
            writer.Write(value.x);
            writer.Write(value.y);
            writer.Write(value.width);
            writer.Write(value.height);
        }

        public global::UnityEngine.Rect Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                throw new InvalidOperationException("typecode is null, struct not supported");
            }

            var length = reader.ReadArrayHeader();
            var x = default(float);
            var y = default(float);
            var width = default(float);
            var height = default(float);
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
                        width = reader.ReadSingle();
                        break;
                    case 3:
                        height = reader.ReadSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var result = new global::UnityEngine.Rect(x, y, width, height);
            return result;
        }
    }
}
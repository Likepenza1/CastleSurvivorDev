using System;
// ReSharper disable CheckNamespace

namespace MessagePack.Unity
{
    public sealed class BoundsFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::UnityEngine.Bounds>
    {
        public void Serialize(ref MessagePackWriter writer, global::UnityEngine.Bounds value, global::MessagePack.MessagePackSerializerOptions options)
        {
            IFormatterResolver resolver = options.Resolver;
            writer.WriteArrayHeader(2);
            resolver.GetFormatterWithVerify<global::UnityEngine.Vector3>().Serialize(ref writer, value.center, options);
            resolver.GetFormatterWithVerify<global::UnityEngine.Vector3>().Serialize(ref writer, value.size, options);
        }

        public global::UnityEngine.Bounds Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                throw new InvalidOperationException("typecode is null, struct not supported");
            }

            IFormatterResolver resolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var center = default(global::UnityEngine.Vector3);
            var size = default(global::UnityEngine.Vector3);
            for (int i = 0; i < length; i++)
            {
                var key = i;
                switch (key)
                {
                    case 0:
                        center = resolver.GetFormatterWithVerify<global::UnityEngine.Vector3>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        size = resolver.GetFormatterWithVerify<global::UnityEngine.Vector3>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var result = new global::UnityEngine.Bounds(center, size);
            return result;
        }
    }
}
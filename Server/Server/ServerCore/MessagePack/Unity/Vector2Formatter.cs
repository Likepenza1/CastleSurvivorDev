// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Buffers;
using MessagePack;
using MessagePack.Formatters;
// ReSharper disable CheckNamespace

#pragma warning disable SA1312 // variable naming
#pragma warning disable SA1402 // one type per file
#pragma warning disable SA1649 // file name matches type name

namespace MessagePack.Unity
{
    public sealed class Vector2Formatter : global::MessagePack.Formatters.IMessagePackFormatter<global::UnityEngine.Vector2>
    {
        public void Serialize(ref MessagePackWriter writer, global::UnityEngine.Vector2 value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(2);
            writer.Write(value.x);
            writer.Write(value.y);
        }

        public global::UnityEngine.Vector2 Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                throw new InvalidOperationException("typecode is null, struct not supported");
            }

            var length = reader.ReadArrayHeader();
            var x = default(float);
            var y = default(float);
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
                    default:
                        reader.Skip();
                        break;
                }
            }

            var result = new global::UnityEngine.Vector2(x, y);
            return result;
        }
    }

}

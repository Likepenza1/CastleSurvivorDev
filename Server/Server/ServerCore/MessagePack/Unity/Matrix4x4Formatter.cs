using System;
// ReSharper disable CheckNamespace

namespace MessagePack.Unity
{
    public sealed class Matrix4x4Formatter : global::MessagePack.Formatters.IMessagePackFormatter<global::UnityEngine.Matrix4x4>
    {
        public void Serialize(ref MessagePackWriter writer, global::UnityEngine.Matrix4x4 value, global::MessagePack.MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(16);
            writer.Write(value.m00);
            writer.Write(value.m10);
            writer.Write(value.m20);
            writer.Write(value.m30);
            writer.Write(value.m01);
            writer.Write(value.m11);
            writer.Write(value.m21);
            writer.Write(value.m31);
            writer.Write(value.m02);
            writer.Write(value.m12);
            writer.Write(value.m22);
            writer.Write(value.m32);
            writer.Write(value.m03);
            writer.Write(value.m13);
            writer.Write(value.m23);
            writer.Write(value.m33);
        }

        public global::UnityEngine.Matrix4x4 Deserialize(ref MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.IsNil)
            {
                throw new InvalidOperationException("typecode is null, struct not supported");
            }

            var length = reader.ReadArrayHeader();
            var __m00__ = default(float);
            var __m10__ = default(float);
            var __m20__ = default(float);
            var __m30__ = default(float);
            var __m01__ = default(float);
            var __m11__ = default(float);
            var __m21__ = default(float);
            var __m31__ = default(float);
            var __m02__ = default(float);
            var __m12__ = default(float);
            var __m22__ = default(float);
            var __m32__ = default(float);
            var __m03__ = default(float);
            var __m13__ = default(float);
            var __m23__ = default(float);
            var __m33__ = default(float);
            for (int i = 0; i < length; i++)
            {
                var key = i;
                switch (key)
                {
                    case 0:
                        __m00__ = reader.ReadSingle();
                        break;
                    case 1:
                        __m10__ = reader.ReadSingle();
                        break;
                    case 2:
                        __m20__ = reader.ReadSingle();
                        break;
                    case 3:
                        __m30__ = reader.ReadSingle();
                        break;
                    case 4:
                        __m01__ = reader.ReadSingle();
                        break;
                    case 5:
                        __m11__ = reader.ReadSingle();
                        break;
                    case 6:
                        __m21__ = reader.ReadSingle();
                        break;
                    case 7:
                        __m31__ = reader.ReadSingle();
                        break;
                    case 8:
                        __m02__ = reader.ReadSingle();
                        break;
                    case 9:
                        __m12__ = reader.ReadSingle();
                        break;
                    case 10:
                        __m22__ = reader.ReadSingle();
                        break;
                    case 11:
                        __m32__ = reader.ReadSingle();
                        break;
                    case 12:
                        __m03__ = reader.ReadSingle();
                        break;
                    case 13:
                        __m13__ = reader.ReadSingle();
                        break;
                    case 14:
                        __m23__ = reader.ReadSingle();
                        break;
                    case 15:
                        __m33__ = reader.ReadSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = default(global::UnityEngine.Matrix4x4);
            ____result.m00 = __m00__;
            ____result.m10 = __m10__;
            ____result.m20 = __m20__;
            ____result.m30 = __m30__;
            ____result.m01 = __m01__;
            ____result.m11 = __m11__;
            ____result.m21 = __m21__;
            ____result.m31 = __m31__;
            ____result.m02 = __m02__;
            ____result.m12 = __m12__;
            ____result.m22 = __m22__;
            ____result.m32 = __m32__;
            ____result.m03 = __m03__;
            ____result.m13 = __m13__;
            ____result.m23 = __m23__;
            ____result.m33 = __m33__;
            return ____result;
        }
    }
}
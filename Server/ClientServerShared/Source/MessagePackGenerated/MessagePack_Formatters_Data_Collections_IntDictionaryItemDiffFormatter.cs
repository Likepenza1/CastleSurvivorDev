// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
#pragma warning disable CS1591 // document public APIs

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Data.Collections
{
    public sealed class IntDictionaryItemDiffFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::DataTypes.Collections.IntDictionaryItemDiff>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::DataTypes.Collections.IntDictionaryItemDiff value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(3);
            writer.Write(value.Key);
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::DataTypes.Collections.CollectionDiffType>(formatterResolver).Serialize(ref writer, value.CollectionDiffType, options);
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::DataTypes.IDataDiff>(formatterResolver).Serialize(ref writer, value.DiffItem, options);
        }

        public global::DataTypes.Collections.IntDictionaryItemDiff Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var __Key__ = default(int);
            var __CollectionDiffType__ = default(global::DataTypes.Collections.CollectionDiffType);
            var __DiffItem__ = default(global::DataTypes.IDataDiff);

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 0:
                        __Key__ = reader.ReadInt32();
                        break;
                    case 1:
                        __CollectionDiffType__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::DataTypes.Collections.CollectionDiffType>(formatterResolver).Deserialize(ref reader, options);
                        break;
                    case 2:
                        __DiffItem__ = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::DataTypes.IDataDiff>(formatterResolver).Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::DataTypes.Collections.IntDictionaryItemDiff(__Key__, __CollectionDiffType__, __DiffItem__);
            reader.Depth--;
            return ____result;
        }
    }

}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name

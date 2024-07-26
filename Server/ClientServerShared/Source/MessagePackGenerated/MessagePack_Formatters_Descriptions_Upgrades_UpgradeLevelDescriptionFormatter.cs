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

namespace MessagePack.Formatters.Descriptions.Upgrades
{
    public sealed class UpgradeLevelDescriptionFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Descriptions.Upgrades.UpgradeLevelDescription>
    {
        // Resource
        private static global::System.ReadOnlySpan<byte> GetSpan_Resource() => new byte[1 + 8] { 168, 82, 101, 115, 111, 117, 114, 99, 101 };
        // UpgradePrice
        private static global::System.ReadOnlySpan<byte> GetSpan_UpgradePrice() => new byte[1 + 12] { 172, 85, 112, 103, 114, 97, 100, 101, 80, 114, 105, 99, 101 };
        // Value
        private static global::System.ReadOnlySpan<byte> GetSpan_Value() => new byte[1 + 5] { 165, 86, 97, 108, 117, 101 };

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Descriptions.Upgrades.UpgradeLevelDescription value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNil();
                return;
            }

            var formatterResolver = options.Resolver;
            writer.WriteMapHeader(3);
            writer.WriteRaw(GetSpan_Resource());
            global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Descriptions.Types.ResourceReference>(formatterResolver).Serialize(ref writer, value.Resource, options);
            writer.WriteRaw(GetSpan_UpgradePrice());
            writer.Write(value.UpgradePrice);
            writer.WriteRaw(GetSpan_Value());
            writer.Write(value.Value);
        }

        public global::Descriptions.Upgrades.UpgradeLevelDescription Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var formatterResolver = options.Resolver;
            var length = reader.ReadMapHeader();
            var ____result = new global::Descriptions.Upgrades.UpgradeLevelDescription();

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.Internal.CodeGenHelpers.ReadStringSpan(ref reader);
                switch (stringKey.Length)
                {
                    default:
                    FAIL:
                      reader.Skip();
                      continue;
                    case 8:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 7305808869231650130UL) { goto FAIL; }

                        ____result.Resource = global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Descriptions.Types.ResourceReference>(formatterResolver).Deserialize(ref reader, options);
                        continue;
                    case 12:
                        if (!global::System.MemoryExtensions.SequenceEqual(stringKey, GetSpan_UpgradePrice().Slice(1))) { goto FAIL; }

                        ____result.UpgradePrice = reader.ReadInt64();
                        continue;
                    case 5:
                        if (global::MessagePack.Internal.AutomataKeyGen.GetKey(ref stringKey) != 435761733974UL) { goto FAIL; }

                        ____result.Value = reader.ReadSingle();
                        continue;

                }
            }

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

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

namespace MessagePack.Formatters.DataTypes.Fields
{
    public sealed class FloatDataFieldDiffFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::DataTypes.Fields.FloatDataFieldDiff>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::DataTypes.Fields.FloatDataFieldDiff value, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            writer.WriteArrayHeader(1);
            writer.Write(value.NewValue);
        }

        public global::DataTypes.Fields.FloatDataFieldDiff Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);
            var length = reader.ReadArrayHeader();
            var __NewValue__ = default(float);

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 0:
                        __NewValue__ = reader.ReadSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::DataTypes.Fields.FloatDataFieldDiff(__NewValue__);
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

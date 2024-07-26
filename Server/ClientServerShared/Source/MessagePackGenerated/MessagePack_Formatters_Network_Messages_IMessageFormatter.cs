// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
#pragma warning disable CS1591 // document public APIs

#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Network.Messages
{
    public sealed class IMessageFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Network.Messages.IMessage>
    {
        private readonly global::System.Collections.Generic.Dictionary<global::System.RuntimeTypeHandle, global::System.Collections.Generic.KeyValuePair<int, int>> typeToKeyAndJumpMap;
        private readonly global::System.Collections.Generic.Dictionary<int, int> keyToJumpMap;

        public IMessageFormatter()
        {
            this.typeToKeyAndJumpMap = new global::System.Collections.Generic.Dictionary<global::System.RuntimeTypeHandle, global::System.Collections.Generic.KeyValuePair<int, int>>(8, global::MessagePack.Internal.RuntimeTypeHandleEqualityComparer.Default)
            {
                { typeof(global::Messages.TestMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(0, 0) },
                { typeof(global::Messages.LogMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(1, 1) },
                { typeof(global::Messages.LoginMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(2, 2) },
                { typeof(global::Messages.LoginConfirmMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(3, 3) },
                { typeof(global::Messages.PlayerDiffMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(4, 4) },
                { typeof(global::Messages.GetRewardCheatMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(5, 5) },
                { typeof(global::Messages.FinishStageMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(6, 6) },
                { typeof(global::Game.Player.Upgrades.UpgradeMessage).TypeHandle, new global::System.Collections.Generic.KeyValuePair<int, int>(7, 7) },
            };
            this.keyToJumpMap = new global::System.Collections.Generic.Dictionary<int, int>(8)
            {
                { 0, 0 },
                { 1, 1 },
                { 2, 2 },
                { 3, 3 },
                { 4, 4 },
                { 5, 5 },
                { 6, 6 },
                { 7, 7 },
            };
        }

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Network.Messages.IMessage value, global::MessagePack.MessagePackSerializerOptions options)
        {
            global::System.Collections.Generic.KeyValuePair<int, int> keyValuePair;
            if (value != null && this.typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out keyValuePair))
            {
                writer.WriteArrayHeader(2);
                writer.WriteInt32(keyValuePair.Key);
                switch (keyValuePair.Value)
                {
                    case 0:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.TestMessage>(options.Resolver).Serialize(ref writer, (global::Messages.TestMessage)value, options);
                        break;
                    case 1:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.LogMessage>(options.Resolver).Serialize(ref writer, (global::Messages.LogMessage)value, options);
                        break;
                    case 2:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.LoginMessage>(options.Resolver).Serialize(ref writer, (global::Messages.LoginMessage)value, options);
                        break;
                    case 3:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.LoginConfirmMessage>(options.Resolver).Serialize(ref writer, (global::Messages.LoginConfirmMessage)value, options);
                        break;
                    case 4:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.PlayerDiffMessage>(options.Resolver).Serialize(ref writer, (global::Messages.PlayerDiffMessage)value, options);
                        break;
                    case 5:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.GetRewardCheatMessage>(options.Resolver).Serialize(ref writer, (global::Messages.GetRewardCheatMessage)value, options);
                        break;
                    case 6:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.FinishStageMessage>(options.Resolver).Serialize(ref writer, (global::Messages.FinishStageMessage)value, options);
                        break;
                    case 7:
                        global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Game.Player.Upgrades.UpgradeMessage>(options.Resolver).Serialize(ref writer, (global::Game.Player.Upgrades.UpgradeMessage)value, options);
                        break;
                    default:
                        break;
                }

                return;
            }

            writer.WriteNil();
        }

        public global::Network.Messages.IMessage Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            if (reader.ReadArrayHeader() != 2)
            {
                throw new global::System.InvalidOperationException("Invalid Union data was detected. Type:global::Network.Messages.IMessage");
            }

            options.Security.DepthStep(ref reader);
            var key = reader.ReadInt32();

            if (!this.keyToJumpMap.TryGetValue(key, out key))
            {
                key = -1;
            }

            global::Network.Messages.IMessage result = null;
            switch (key)
            {
                case 0:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.TestMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                case 1:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.LogMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                case 2:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.LoginMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                case 3:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.LoginConfirmMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                case 4:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.PlayerDiffMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                case 5:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.GetRewardCheatMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                case 6:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Messages.FinishStageMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                case 7:
                    result = (global::Network.Messages.IMessage)global::MessagePack.FormatterResolverExtensions.GetFormatterWithVerify<global::Game.Player.Upgrades.UpgradeMessage>(options.Resolver).Deserialize(ref reader, options);
                    break;
                default:
                    reader.Skip();
                    break;
            }

            reader.Depth--;
            return result;
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name

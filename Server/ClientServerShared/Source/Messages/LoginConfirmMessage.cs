using DataTypes;
using Descriptions;
using MessagePack;
using Network.Messages;

namespace Messages
{
    [MessagePackObject]
    public class LoginConfirmMessage : IMessage
    {
        [Key(0)]
        public IDataDiff PlayerData;

        [Key(1)]
        public GameRules GameRules;

        public LoginConfirmMessage()
        {
            
        }
    }

}
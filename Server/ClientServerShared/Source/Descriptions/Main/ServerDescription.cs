using Descriptions.Core;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Main
{
    [MessagePackObject(true)]
    public class ServerDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public string ConnectionKey = "game";
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public bool IsSecure = true;
    }

}
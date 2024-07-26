using Descriptions.Core;
using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Main
{
    [MessagePackObject(true)]
    public class ResourceDescription : DescriptionWithId
    {
        [ShowInInspector]
        public long StartValue;
        
        [ShowInInspector]
        public SpriteReference Icon;
    }
}
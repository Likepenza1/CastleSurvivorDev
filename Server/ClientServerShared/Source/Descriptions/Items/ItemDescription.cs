using Descriptions.Core;
using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions.Items
{
    [MessagePackObject(true)]
    public class ItemDescription : DescriptionWithId
    {
        [BoxGroup("Info")]
        [ShowInInspector]
        [LabelWidth(300)]
        public AddressableAsset<GameObject> Prefab;
        
        [BoxGroup("Info")]
        [ShowInInspector]
        [LabelWidth(300)]
        public SpriteReference Icon;
        
        [BoxGroup("Info")]
        [ShowInInspector]
        [LabelWidth(300)]
        public ItemType Type;
    }
}
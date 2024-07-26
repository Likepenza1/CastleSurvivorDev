using Descriptions.Core;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Main
{
    [MessagePackObject(true)]
    public class PlayerDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public int MaxAmmo = 6;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public float AmmoRestoreTime = 1f;
    }
}
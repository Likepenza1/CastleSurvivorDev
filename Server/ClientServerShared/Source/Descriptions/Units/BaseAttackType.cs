using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions.Units
{
    [MessagePackObject(true)]
    [Union(0, typeof(RangedAttackType))]
    [Union(1, typeof(MeleeAttackType))]
    public abstract class BaseAttackType
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Base")]
        public float Range = 1f;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Base")]
        public float Interval = 1f;

        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Base")]
        public float AnimationTime = 0.1f;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Base")]
        public AddressableAsset<GameObject> HitFx;
    }

}
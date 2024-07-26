using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions.Units
{
    [MessagePackObject(true)]
    public class RangedAttackType : BaseAttackType
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Ranged specific")]
        public float ProjectileSpeed;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Ranged specific")]
        public AddressableAsset<GameObject> Projectile;
    }
}
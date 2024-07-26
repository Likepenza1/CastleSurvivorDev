using Descriptions.Core;
using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions.Units
{
    [MessagePackObject(true)]
    public class UnitDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("View")]
        public AddressableAsset<GameObject> Prefab;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Stats")]
        public float MoveSpeed;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Stats")]
        public float BaseDamage;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Stats")]
        public float BaseHealth;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Attack")]
        public BaseAttackType AttackType = new MeleeAttackType();
    }
}
using Descriptions.Rewards;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Stage
{
    [MessagePackObject(true)]
    public class WaveDescription
    {
        [ShowInInspector]
        public float SpawnWaveDuration = 1f;
        
        [ShowInInspector]
        [PropertySpace(SpaceAfter = 20)]
        public float WaveStartDelay;

        [ShowInInspector]
        public float DamagePercentModifier = 1f;
        
        [ShowInInspector]
        public float HealthPercentModifier = 1f;
        
        [ShowInInspector]
        public float MoveSpeedMultiplier = 1f;
        
        [ShowInInspector]
        [HideReferenceObjectPicker]
        [PropertySpace(SpaceAfter = 20)]
        [ListDrawerSettings(ShowIndexLabels = true, ListElementLabelName = "UnitsInfo")]
        public CommonUnitsSpawnInfo[] CommonUnits = {};
        
        [ShowInInspector]
        [HideReferenceObjectPicker]
        [PropertySpace(SpaceAfter = 20)]
        [ListDrawerSettings(ShowIndexLabels = true, ListElementLabelName = "UnitInfo")]
        public SpecialUnitSpawnInfo[] SpecialUnits = {};
        
        [ShowInInspector]
        public IReward? Reward;
    }
}
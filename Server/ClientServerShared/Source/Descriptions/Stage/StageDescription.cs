using System.Diagnostics.CodeAnalysis;
using Descriptions.Core;
using Descriptions.Rewards;
using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Stage
{
    [MessagePackObject(true)]
    public class StageDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [InfoBox("Удалим это когда будет прогрессия")]
        [BoxGroup("Draft player")]
        public float PlayerHealth;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Draft player")]
        public float EachPlayerDamage;
        
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("View")]
        public SceneReference Scene;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [HideReferenceObjectPicker]
        [ListDrawerSettings(ShowIndexLabels = true)]
        [BoxGroup("Waves")]
        public WaveDescription[] Waves = System.Array.Empty<WaveDescription>();

        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Reward")]
        public IReward? CompleteReward;
    }
}
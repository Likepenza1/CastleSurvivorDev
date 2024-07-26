using Descriptions.Core;
using MessagePack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions.Main
{
    [MessagePackObject(true)]
    public class AppearanceDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public int HairsCount;
        
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public int EyesCount;

        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public Color[] HairColors;
    }

}
using System.Collections.Generic;
using Descriptions.Core;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Upgrades
{
    [MessagePackObject(true)]
    public class UpgradeDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("View")]
        public string Name;
        
        [IgnoreMember]
        public int MaxLevel => Levels.Count - 1;
        
        [TableList(AlwaysExpanded = true, DrawScrollView = true, ShowIndexLabels = true)]
        public List<UpgradeLevelDescription> Levels = new();
        
        
        [IgnoreMember]
        public UpgradeLevelDescription this[int level] => Levels[level];
    }
}
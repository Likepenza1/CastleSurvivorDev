using Descriptions.Core;
using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Main
{
    [MessagePackObject(true)]
    public class StagesSequenceDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Settings")]
        public DescriptionReference[] Stages;

        [IgnoreMember]
        public DescriptionReference this[int index] => Stages[index];
    }
}
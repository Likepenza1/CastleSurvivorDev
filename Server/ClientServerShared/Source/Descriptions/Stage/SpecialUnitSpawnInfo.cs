using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Stage
{
    [MessagePackObject(true)]
    [HideReferenceObjectPicker]
    public class SpecialUnitSpawnInfo
    {
        public string UnitInfo => $"{Unit.Id}, delay = [{DelaySinceStart}]";
        
        public DescriptionReference Unit;
        public float DelaySinceStart;
    }
}
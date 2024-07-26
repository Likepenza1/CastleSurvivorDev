using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Stage
{
    [MessagePackObject(true)]
    [HideReferenceObjectPicker]
    public class CommonUnitsSpawnInfo
    {
        [IgnoreMember]
        public string UnitsInfo => $"{Unit.Id}, count = [{Count}]";
        
        public DescriptionReference Unit;
        public int Count;
    }
}
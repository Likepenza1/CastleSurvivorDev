using Sirenix.OdinInspector;

namespace Descriptions.Core
{
    public abstract class DescriptionWithId : IDescription
    {
        [ShowInInspector]
        [PropertyOrder(0)]
        [BoxGroup("Id", ShowLabel = false)]
        [ReadOnly]
        public string Id;
    }
}
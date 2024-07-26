using Descriptions.Core;
using Descriptions.Types;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Main
{
    [MessagePackObject(true)]
    public class ScenesDescription : DescriptionWithId
    {
        [ShowInInspector]
        [LabelWidth(300)]
        [BoxGroup("Main")]
        public SceneReference MainMenu;
    }
}
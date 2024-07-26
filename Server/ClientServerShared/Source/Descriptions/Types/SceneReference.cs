using System;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Types
{
    [HideReferenceObjectPicker]
    [InlineProperty]
    [MessagePackObject(true)]
    [Serializable]
    public struct SceneReference
    {
        [ShowInInspector]
        [Searchable]
        [HideLabel]
        [ValueDropdown("GetAllScenes", IsUniqueList = true, DropdownTitle = "Select Scene", DrawDropdownForListElements = false)]
        public string Key { get; set; }

#if UNITY_EDITOR

        private System.Collections.IEnumerable GetAllScenes()
        {
            var list = new ValueDropdownList<string>();

            var settings = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings;

            if (settings)
            {
                foreach (var group in settings.groups)
                {
                    foreach (var entry in group.entries)
                    {
                        if (entry.IsScene)
                        {
                            list.Add(entry.address);
                        }
                    }
                }
            }

            return list;
        }
#endif
    }
}
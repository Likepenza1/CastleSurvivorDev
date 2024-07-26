using System.Collections;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Types
{
    [HideReferenceObjectPicker]
    [InlineProperty]
    [MessagePackObject(true)]
    public struct AddressableAsset<T>
    {
        [HideLabel]
        [ValueDropdown("TreeViewOfAddressable")]
        public string Key;
        
        #if UNITY_EDITOR
        private IEnumerable TreeViewOfAddressable()
        {
            var list = new ValueDropdownList<string>();
            
            var settings = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings;
 
            if (settings)
            {
                foreach (var group in settings.groups)
                {
                    foreach (var entry in group.entries)
                    {
                        if (entry.MainAsset is T)
                        {
                            var item = new ValueDropdownItem<string>();
                            item.Text = $"{group.name}/{entry.address}";
                            item.Value = entry.address;
                            list.Add(item);
                        }
                    }
                }
            }

            return list;
        }
        #endif

        public override string ToString()
        {
            return Key;
        }
    }

}
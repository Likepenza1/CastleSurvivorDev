using MessagePack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Descriptions.Types
{
    [HideReferenceObjectPicker]
    [InlineProperty]
    [MessagePackObject(true)]
    public struct SpriteReference
    {
        [HideLabel]
        [ValueDropdown("TreeViewOfAddressable")]
        public string Key;
        
        #if UNITY_EDITOR
        private System.Collections.IEnumerable TreeViewOfAddressable()
        {
            var list = new ValueDropdownList<string>();
            
            var settings = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings;
 
            if (settings)
            {
                foreach (var group in settings.groups)
                {
                    foreach (var entry in group.entries)
                    {
                        if (entry.MainAsset is UnityEngine.U2D.SpriteAtlas atlas)
                        {
                            if (atlas.spriteCount == 0)
                            {
                                return list;
                            }
                            
                            var sprites = new Sprite[atlas.spriteCount];
                            atlas.GetSprites(sprites);
                            
                            foreach (var sprite in sprites)
                            {
                                var spriteName = sprite.name.Remove(sprite.name.Length - 7, 7);
                                var item = new ValueDropdownItem<string>();
                                item.Text = $"{atlas.name}/{spriteName}";
                                item.Value = item.Text;
                                list.Add(item);
                            }
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
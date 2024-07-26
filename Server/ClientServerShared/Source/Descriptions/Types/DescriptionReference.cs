using System;
using System.Collections;
using System.IO;
using MessagePack;
using Sirenix.OdinInspector;

namespace Descriptions.Types
{
    [HideReferenceObjectPicker]
    [InlineProperty]
    [MessagePackObject(true)]
    [Serializable]
    public struct DescriptionReference
    {
        [HideLabel]
        [Searchable]
        [ValueDropdown("TreeViewOfDescriptions")]
        public string Id;
        
        private IEnumerable TreeViewOfDescriptions()
        {
            var path = $"{UnityEngine.Application.dataPath}/../Server/ClientServerShared/Descriptions/";
            var list = new ValueDropdownList<string>();
            foreach (var groupPath in Directory.GetDirectories(path))
            {
                foreach (var file in Directory.GetFiles(groupPath))
                {
                    if (file.EndsWith(".json"))
                    {
                        var parentDirectory = Directory.GetParent(file);
                        var group = parentDirectory.Name;
                        var name = Path.GetFileName(file);
                        var id = name.Replace(".json", "");
                    
                        var item = new ValueDropdownItem<string>();
                        item.Text = $"{group}/{id}";
                        item.Value = id;
                        list.Add(item);
                    }
                }
            }
            
            return list;
        }
    }
}
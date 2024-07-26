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
    public struct ResourceReference
    {
        [HideLabel]
        [Searchable]
        [ValueDropdown("TreeViewOfDescriptions")]
        public string Id;

        #if UNITY_EDITOR
        
  
        private IEnumerable TreeViewOfDescriptions()
        {
            var groupPath = $"{UnityEngine.Application.dataPath}/../Server/ClientServerShared/Descriptions/Resources/";

            var list = new ValueDropdownList<string>();
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

            return list;
        }
        #endif
    }
}
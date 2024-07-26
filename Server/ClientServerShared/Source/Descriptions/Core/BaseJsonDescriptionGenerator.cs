using System.Collections.Generic;
using System.IO;
using MessagePack;

namespace Descriptions.Core
{

    public abstract class BaseJsonDescriptionGenerator<T> : BaseDescriptionGenerator<T>
        where T : IDescription
    {
        protected string Path => $"{DefaultPath}{SubPath}";
        protected string DefaultPath => "Descriptions/";
        protected abstract string SubPath { get; }
        
        public override IEnumerable<(string id, T description)> Generate()
        {
            var appPath = AppPathGetter.Get();
            var path = appPath + Path;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                if (file.EndsWith(".json"))
                {
                    var json = File.ReadAllText(file);
                    var data = MessagePackSerializer.ConvertFromJson(json);
                    var description = MessagePackSerializer.Deserialize<T>(data);
                    yield return GetDescription(description);
                }
            }
        }

        protected abstract (string, T) GetDescription(T description);
    }
}
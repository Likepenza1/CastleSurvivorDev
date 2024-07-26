using System;
using System.IO;
using MessagePack;

namespace Descriptions.Core
{
    public class SingleJsonDescriptionGenerator<T>
        where T : DescriptionWithId
    {
        private readonly string _id;
        protected string Path => "Descriptions/Main/";

        public SingleJsonDescriptionGenerator(string id)
        {
            _id = id;
        }

        public T Generate()
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
                if (file.EndsWith($"{_id}.json"))
                {
                    var json = File.ReadAllText(file);
                    var data = MessagePackSerializer.ConvertFromJson(json);
                    var description = MessagePackSerializer.Deserialize<T>(data);
                    return description;
                }
            }

            throw new Exception($"description with id {_id} not found");
        }
    }
}
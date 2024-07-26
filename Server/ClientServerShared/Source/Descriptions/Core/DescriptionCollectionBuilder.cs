using System.Collections.Generic;

namespace Descriptions.Core
{
    public static class DescriptionCollectionBuilder
    {
        public static Dictionary<string, T> Build<T>(IEnumerable<(string id, T description)> descriptions) where T : IDescription
        {
            var result = new Dictionary<string, T>();
            
            foreach (var (id, description) in descriptions)
            {
                result.Add(id, description);
            }

            return result;
        }
        
        public static T Build<T>(T description) where T : IDescription
        {
            return description;
        }
    }
}
using System.Collections.Generic;

namespace Descriptions.Core
{
    public abstract class BaseDescriptionGenerator<T>
        where T : IDescription
    {
        public abstract IEnumerable<(string id, T description)> Generate();
    }

    public interface IDescription
    {
        
    }
}
using System.Collections.Generic;
using Core.Fields;

namespace Server.ServerLogic.Base
{
    public interface IActiveCollection<T>
    {
        public TriggerField<T> Added { get; }
        public TriggerField<T> Removed { get; }

        public IEnumerable<T> GetAll();
    }
}
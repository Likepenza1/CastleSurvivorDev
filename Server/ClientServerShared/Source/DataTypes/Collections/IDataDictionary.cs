using System;
using System.Collections.Generic;

namespace DataTypes.Collections
{
    public interface IDataDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        public event Action<TKey, TValue> Added;
        public event Action<TKey, TValue> Removed;
        public void Add(TKey key, TValue data);
        public void Remove(TKey key);
    }
}
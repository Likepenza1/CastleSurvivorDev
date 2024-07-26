using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataTypes.Collections
{
    public abstract class DictionaryData<TKey, TValue, TItemDiff> : IData, IDataDictionary<TKey, TValue>
    where TValue : IData, new()
    where TItemDiff : DictionaryItemDiff<TKey>
    {
        public event Action<TKey, TValue> Added;
        public event Action<TKey, TValue> Removed;

        private readonly List<TKey> _added = new List<TKey>(); 
        private readonly List<TKey> _removed = new List<TKey>(); 
        private readonly List<TKey> _keys = new List<TKey>();

        
        private readonly Dictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();
        
        public TValue this[TKey id] => _items[id];
        
        public void Add(TKey key, TValue data)
        {
            _removed.Remove(key);
            _added.Add(key);
            _items.Add(key, data);
            _keys.Add(key);
            Added?.Invoke(key, data);
        }

        public void Remove(TKey key)
        {
            if (_items.TryGetValue(key, out var value))
            {
                _added.Remove(key);
                _items.Remove(key);
                _keys.Remove(key);
                _removed.Add(key);
                Removed?.Invoke(key, value);
            }
        }

        public bool IsDirty
        {
            get
            {
                if (_added.Count > 0)
                {
                    return true;
                }

                if (_removed.Count > 0)
                {
                    return true;
                }

                foreach (var item in _items)
                {
                    if (item.Value.IsDirty)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public IDataDiff GetDiff()
        {
            var diffs = new List<IDataDiff>();
            
            foreach (var key in _added)
            {
                var itemDiff = _items[key].GetWhole();
                var dictionaryItemDiff = CreateDictionaryItemDiff(CollectionDiffType.Added, key, itemDiff);
                diffs.Add(dictionaryItemDiff);
            }

            foreach (var key in _keys)
            {
                var itemDiff = _items[key].GetDiff();

                if (itemDiff != null && !_added.Contains(key))
                {
                    var dictionaryItemDiff = CreateDictionaryItemDiff(CollectionDiffType.Updated, key, itemDiff);
                    diffs.Add(dictionaryItemDiff);
                }
            }

            foreach (var key in _removed)
            {
                var dictionaryItemDiff = CreateDictionaryItemDiff(CollectionDiffType.Removed, key, null);
                diffs.Add(dictionaryItemDiff);
            }

            return new DictionaryDiff(DiffType.Diff, diffs.ToArray());
        }

        protected abstract TItemDiff CreateDictionaryItemDiff(CollectionDiffType type, TKey key, IDataDiff itemDiff);

        public IDataDiff GetWhole()
        {
            var diffs = new List<IDataDiff>();
            
            foreach (var item in _items)
            {
                var itemDiff = item.Value.GetWhole();
                var dictionaryItemDiff = CreateDictionaryItemDiff(CollectionDiffType.Added, item.Key, itemDiff);
                diffs.Add(dictionaryItemDiff);
            }

            return new DictionaryDiff(DiffType.Whole, diffs.ToArray());
        }

        public void Apply(IDataDiff diff)
        {
            var dataDiff = (DictionaryDiff)diff;
            
            switch (dataDiff.DiffType)
            {
                case DiffType.Diff:
                    ApplyDiff(dataDiff);
                    break;
                case DiffType.Whole:
                    ApplyWhole(dataDiff);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ApplyWhole(DictionaryDiff diff)
        {
            RemoveAll();
            ClearAll();
            ApplyDiff(diff);
        }
        
        private void ApplyDiff(DictionaryDiff diff)
        {
            for (int i = 0; i < diff.Data.Length; i++)
            {
                var diffItem = (DictionaryItemDiff<TKey>)diff.Data[i];
                ApplyDiffItem(diffItem, diff);
            }
        }

        private void ApplyDiffItem(DictionaryItemDiff<TKey> diff, DictionaryDiff dictionaryDiff)
        {
            switch (diff.CollectionDiffType)
            {
                case CollectionDiffType.Removed:
                {
                    Remove(diff.Key);
                    break;
                }
                
                case CollectionDiffType.Added:
                {
                    if (_items.ContainsKey(diff.Key))
                    {
                        #if UNITY_EDITOR
                        
                        var count = dictionaryDiff.Data.Count(item => item is DictionaryItemDiff<TKey> d && d.Key.Equals(diff.Key));

                        UnityEngine.Debug.LogError
                        (
                            "duplicate on try add new item to dictionary data" +
                            $"key = {diff.Key}, key use count in diff = {count}" +
                            $"collection type = {GetType()}, items type = {typeof(TValue)}"
                        );
                        
                        UnityEngine.Debug.LogError("trying apply diff instead of add new item...");

                        #endif
                        
                        var item = _items[diff.Key];
                        item.Apply(diff.DiffItem);
                    }
                    else
                    {
                        var item = new TValue();
                        item.Apply(diff.DiffItem);
                        Add(diff.Key, item);
                    }
                    

                    break;
                }

                case CollectionDiffType.Updated:
                {
                    var item = _items[diff.Key];
                    item.Apply(diff.DiffItem);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ClearChanged()
        {
            _added.Clear();
            _removed.Clear();

            foreach (var item in _items)
            {
                item.Value.ClearChanged();
            }
        }

        public void ClearAll()
        {
            _added.Clear();
            _removed.Clear();
            _items.Clear();
            _keys.Clear();
        }
        
        public void RemoveAll()
        {
            var keys = _items.Keys.ToArray();

            foreach (var key in keys)
            {
                Remove(key);
            }
        }
        
        public IEnumerable<TKey> GetKeys() => _keys;
        public IEnumerable<TValue> GetValues() => _items.Values;

        public int Count => _items.Count;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsId(TKey key)
        {
            return _items.ContainsKey(key);
        }
    }

}
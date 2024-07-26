using UnityEngine;

namespace DataTypes.Collections
{
    public class Vector2IntKeyDictionaryData<TValue> : DictionaryData<Vector2Int, TValue, Vector2IntDictionaryItemDiff>
        where TValue : IData, new()
    {
        protected override Vector2IntDictionaryItemDiff CreateDictionaryItemDiff(CollectionDiffType type, Vector2Int key, IDataDiff itemDiff)
        {
            return new Vector2IntDictionaryItemDiff(key, type, itemDiff);
        }
    }
}
using MessagePack;
using UnityEngine;

namespace DataTypes.Collections
{
    [MessagePackObject]
    public class Vector2IntDictionaryItemDiff : DictionaryItemDiff<Vector2Int>
    {
        public Vector2IntDictionaryItemDiff(Vector2Int key, CollectionDiffType collectionDiffType, IDataDiff diff) : base(key, collectionDiffType, diff)
        {
        }
    }
}
using MessagePack;

namespace DataTypes.Collections
{
    [MessagePackObject]
    public class IntDictionaryItemDiff : DictionaryItemDiff<int>
    {
        public IntDictionaryItemDiff(int key, CollectionDiffType collectionDiffType, IDataDiff diff) : base(key, collectionDiffType, diff)
        {
        }
    }
}
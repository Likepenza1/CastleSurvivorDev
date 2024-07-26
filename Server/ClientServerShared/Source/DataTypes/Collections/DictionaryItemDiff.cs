using MessagePack;

namespace DataTypes.Collections
{
    [MessagePackObject]
    public class DictionaryItemDiff<TKey> : IDataDiff
    {
        [Key(0)]
        public TKey Key { get; }
        
        [Key(1)]
        public CollectionDiffType CollectionDiffType { get; }

        [Key(2)]
        public IDataDiff DiffItem { get; }
        
        [IgnoreMember]
        public IDataDiff[] Data { get; }

        public DictionaryItemDiff(TKey key, CollectionDiffType collectionDiffType, IDataDiff diffItem)
        {
            CollectionDiffType = collectionDiffType;
            Key = key;
            DiffItem = diffItem;
            Data = new IDataDiff[1];
            Data[0] = diffItem;
        }
    }
}
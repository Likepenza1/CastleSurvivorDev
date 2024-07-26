using MessagePack;

namespace DataTypes.Collections
{
    [MessagePackObject]
    public class StringDictionaryItemDiff : DictionaryItemDiff<string>
    {
        public StringDictionaryItemDiff(string key, CollectionDiffType collectionDiffType, IDataDiff diff) : base(key, collectionDiffType, diff)
        {
        }
    }
}
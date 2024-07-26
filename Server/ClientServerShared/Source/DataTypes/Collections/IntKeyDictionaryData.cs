namespace DataTypes.Collections
{
    public class IntKeyDictionaryData<TValue> : DictionaryData<int, TValue, IntDictionaryItemDiff>
        where TValue : IData, new()
    {
        protected override IntDictionaryItemDiff CreateDictionaryItemDiff(CollectionDiffType type, int key, IDataDiff itemDiff)
        {
            return new IntDictionaryItemDiff(key, type, itemDiff);
        }
    }
}
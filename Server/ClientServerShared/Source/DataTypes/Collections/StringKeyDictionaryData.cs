namespace DataTypes.Collections
{
    public class StringKeyDictionaryData<TValue> : DictionaryData<string, TValue, StringDictionaryItemDiff>
        where TValue : IData, new()
    {
        protected override StringDictionaryItemDiff CreateDictionaryItemDiff(CollectionDiffType type, string key, IDataDiff itemDiff)
        {
            return new StringDictionaryItemDiff(key, type, itemDiff);
        }
    }

}
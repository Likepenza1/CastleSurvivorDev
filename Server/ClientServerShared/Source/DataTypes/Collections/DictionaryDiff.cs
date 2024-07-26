using MessagePack;

namespace DataTypes.Collections
{
    [MessagePackObject]
    public class DictionaryDiff : IDataDiff
    {
        [Key(0)]
        public DiffType DiffType;
        [Key(1)]
        public IDataDiff[] Data { get; }

        public DictionaryDiff(DiffType diffType, IDataDiff[] diffs)
        {
            DiffType = diffType;
            Data = diffs;
        }
    }
}
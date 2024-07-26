using DataTypes.Collections;
using DataTypes.Fields;
using MessagePack;

namespace DataTypes
{
    [Union(0, typeof(IntDataFieldDiff))]
    [Union(1, typeof(StringDataFieldDiff))]
    [Union(2, typeof(DataDiff))]
    [Union(3, typeof(DictionaryDiff))]
    [Union(4, typeof(StringDictionaryItemDiff))]
    [Union(5, typeof(ByteDataFieldDiff))]
    [Union(6, typeof(ULongDataFieldDiff))]
    [Union(7, typeof(LongDataFieldDiff))]
    [Union(8, typeof(BoolDataFieldDiff))]
    [Union(9, typeof(IntDictionaryItemDiff))]
    [Union(10, typeof(Vector2IntDataFieldDiff))]
    [Union(11, typeof(FloatDataFieldDiff))]
    [Union(12, typeof(Vector3DataFieldDiff))]
    [Union(13, typeof(Vector2IntDictionaryItemDiff))]
    public interface IDataDiff
    {
        public IDataDiff[] Data { get; }
    }
}
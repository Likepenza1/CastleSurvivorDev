using MessagePack;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class ULongDataFieldDiff : DataFieldDiff<ulong>
    {
        public ULongDataFieldDiff(ulong newValue) : base(newValue)
        {
        }
    }
}
using MessagePack;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class LongDataFieldDiff : DataFieldDiff<long>
    {
        public LongDataFieldDiff(long newValue) : base(newValue)
        {
        }
    }
}
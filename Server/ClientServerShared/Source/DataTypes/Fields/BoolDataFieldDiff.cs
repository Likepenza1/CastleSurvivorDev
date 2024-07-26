using MessagePack;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class BoolDataFieldDiff : DataFieldDiff<bool>
    {
        public BoolDataFieldDiff(bool newValue) : base(newValue)
        {
        }
    }
}
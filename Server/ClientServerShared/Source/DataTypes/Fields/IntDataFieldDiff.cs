using MessagePack;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class IntDataFieldDiff : DataFieldDiff<int>
    {
        public IntDataFieldDiff(int newValue) : base(newValue)
        {
        }
    }
}
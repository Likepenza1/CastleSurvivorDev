using MessagePack;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class StringDataFieldDiff : DataFieldDiff<string>
    {
        public StringDataFieldDiff(string newValue) : base(newValue)
        {
        }
    }
}
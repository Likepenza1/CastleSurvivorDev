using MessagePack;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class FloatDataFieldDiff : DataFieldDiff<float>
    {
        public FloatDataFieldDiff(float newValue) : base(newValue)
        {
        }
    }
}
using MessagePack;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class ByteDataFieldDiff : DataFieldDiff<byte>
    {
        public ByteDataFieldDiff(byte newValue) : base(newValue)
        {
        }
    }
}
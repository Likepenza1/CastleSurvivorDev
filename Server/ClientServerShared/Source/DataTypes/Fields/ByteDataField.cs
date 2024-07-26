namespace DataTypes.Fields
{
    public class ByteDataField : DataField<byte, ByteDataFieldDiff>
    {
        protected override ByteDataFieldDiff CreateDiff()
        {
            return new ByteDataFieldDiff(Value);
        }
    }

}
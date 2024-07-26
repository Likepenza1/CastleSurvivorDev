namespace DataTypes.Fields
{
    public class ULongDataField : DataField<ulong, ULongDataFieldDiff>
    {
        public ULongDataField(ulong value = default)
        {
            _value = value;
        }
        
        protected override ULongDataFieldDiff CreateDiff()
        {
            return new ULongDataFieldDiff(Value);
        }
    }

}
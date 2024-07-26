namespace DataTypes.Fields
{
    public class IntDataField : DataField<int, IntDataFieldDiff>
    {
        public IntDataField(int defaultValue = default)
        {
            _value = defaultValue;
        }

        public IntDataField()
        {
            _value = 0;
        }
        
        protected override IntDataFieldDiff CreateDiff()
        {
            return new IntDataFieldDiff(Value);
        }
    }

}
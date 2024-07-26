namespace DataTypes.Fields
{
    public class StringDataField : DataField<string, StringDataFieldDiff>
    {
        public StringDataField()
        {
            
        }

        public StringDataField(string value)
        {
            Value = value;
        }
        
        protected override StringDataFieldDiff CreateDiff()
        {
            return new StringDataFieldDiff(Value);
        }
    }
}
namespace DataTypes.Fields
{
    public class FloatDataField : DataField<float, FloatDataFieldDiff>
    {
        public FloatDataField(float defaultValue = 0f)
        {
            _value = defaultValue;
        }
        
        protected override FloatDataFieldDiff CreateDiff()
        {
            return new FloatDataFieldDiff(Value);
        }
    }
}
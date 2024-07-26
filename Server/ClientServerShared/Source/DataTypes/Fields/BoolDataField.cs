namespace DataTypes.Fields
{
    public class BoolDataField : DataField<bool, BoolDataFieldDiff>
    {
        protected override BoolDataFieldDiff CreateDiff()
        {
            return new BoolDataFieldDiff(Value);
        }
    }
}
namespace DataTypes.Fields
{
    public class LongDataField : DataField<long, LongDataFieldDiff>
    {
        protected override LongDataFieldDiff CreateDiff()
        {
            return new LongDataFieldDiff(Value);
        }
    }
}
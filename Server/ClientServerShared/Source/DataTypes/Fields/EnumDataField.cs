using System;

namespace DataTypes.Fields
{
    public class EnumDataField<T> : BaseEnumDataField<T, IntDataFieldDiff>
        where T : Enum
    {
        protected override IntDataFieldDiff CreateDiff()
        {
            return new IntDataFieldDiff(Convert.ToInt32(Value));
        }
    }
}
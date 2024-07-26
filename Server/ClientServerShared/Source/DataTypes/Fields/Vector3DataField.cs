using UnityEngine;

namespace DataTypes.Fields
{
    public class Vector3DataField : DataField<Vector3, Vector3DataFieldDiff>
    {
        protected override Vector3DataFieldDiff CreateDiff()
        {
            return new Vector3DataFieldDiff(Value);
        }
    }
}
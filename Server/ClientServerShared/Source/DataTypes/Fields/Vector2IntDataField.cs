using UnityEngine;

namespace DataTypes.Fields
{
    public class Vector2IntDataField : DataField<Vector2Int, Vector2IntDataFieldDiff>
    {
        protected override Vector2IntDataFieldDiff CreateDiff()
        {
            return new Vector2IntDataFieldDiff(Value);
        }
    }
}
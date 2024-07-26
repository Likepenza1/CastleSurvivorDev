using MessagePack;
using UnityEngine;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class Vector2IntDataFieldDiff : DataFieldDiff<Vector2Int>
    {
        public Vector2IntDataFieldDiff(Vector2Int newValue) : base(newValue)
        {
        }
    }
}
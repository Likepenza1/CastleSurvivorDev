using MessagePack;
using UnityEngine;

namespace DataTypes.Fields
{
    [MessagePackObject]
    public class Vector3DataFieldDiff : DataFieldDiff<Vector3>
    {
        public Vector3DataFieldDiff(Vector3 newValue) : base(newValue)
        {
        }
    }
}
using System;
using MessagePack;

namespace DataTypes.Fields
{
    public abstract class DataFieldDiff<T> : IDataDiff
    {
        [Key(0)]
        public T NewValue;

        public DataFieldDiff(T newValue)
        {
            NewValue = newValue;
        }

        [IgnoreMember]
        public IDataDiff[] Data => Array.Empty<IDataDiff>();
    }
}
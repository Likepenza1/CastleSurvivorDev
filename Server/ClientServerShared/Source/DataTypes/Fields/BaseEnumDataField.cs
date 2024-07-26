using System;
using System.Collections.Generic;
using Core.Fields;

namespace DataTypes.Fields
{
    public abstract class BaseEnumDataField<TValue, TDiff> : IData, IField<TValue>
        where TDiff : DataFieldDiff<int>
        where TValue : Enum
    {
        protected TValue _value;
        public event FieldChanged<TValue> Changed;

        public virtual TValue Value
        {
            get => _value;
            set
            {
                var old = Value;
                _value = value;

                if (!EqualityComparer<TValue>.Default.Equals(old, value))
                {
                    IsDirty = true;
                    Changed?.Invoke(old, _value);
                }
            }
        }
        public bool IsDirty { get; private set; }

        public IDataDiff GetDiff()
        {
            if (!IsDirty)
            {
                return null;
            }
            
            return CreateDiff();
        }

        public IDataDiff GetWhole()
        {
            return CreateDiff();
        }

        public void Apply(IDataDiff diff)
        {
            var fieldDiff = (DataFieldDiff<int>)diff;
            var newValue = fieldDiff.NewValue;
            Value = (TValue)(object)newValue;
        }

        public void ClearChanged()
        {
            IsDirty = false;
        }

        protected abstract TDiff CreateDiff();
    }
}
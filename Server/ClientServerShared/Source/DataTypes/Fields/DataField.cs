using System.Collections.Generic;
using Core.Fields;

namespace DataTypes.Fields
{
    public abstract class DataField<TValue, TDiff> : IData, IField<TValue>
    where TDiff : DataFieldDiff<TValue>
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
            var fieldDiff = (DataFieldDiff<TValue>)diff;
            Value = fieldDiff.NewValue;
        }

        public void ClearChanged()
        {
            IsDirty = false;
        }

        protected abstract TDiff CreateDiff();
    }
}
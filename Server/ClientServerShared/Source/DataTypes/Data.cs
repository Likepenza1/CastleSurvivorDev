using System.Collections.Generic;

namespace DataTypes
{
    public class Data : IData
    {
        public bool IsDirty
        {
            get
            {
                foreach (var data in _data)
                {
                    if (data.IsDirty)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private readonly List<IData> _data = new List<IData>();

        protected void AddData(IData data)
        {
            _data.Add(data);
        }
        
        public IDataDiff GetDiff()
        {
            var changed = new IDataDiff[_data.Count];

            for (var i = 0; i < changed.Length; i++)
            {
                changed[i] = _data[i].GetDiff();
            }

            return new DataDiff(changed);
        }

        public IDataDiff GetWhole()
        {
            var diffs = new IDataDiff[_data.Count];

            for (var i = 0; i < diffs.Length; i++)
            {
                diffs[i] = _data[i].GetWhole();
            }
            
            return new DataDiff(diffs);
        }

        public void Apply(IDataDiff diff)
        {
            if (diff == null)
            {
                return;
            }
            
            var dataDiff = (DataDiff)diff;
            var index = 0;
            
            foreach (var itemData in _data)
            {
                var itemDiff = dataDiff.Data[index];

                if (itemDiff != null)
                {
                    itemData.Apply(itemDiff);
                }
                
                index++;
            }
        }
        
        public void ClearChanged()
        {
            foreach (var data in _data)
            {
                data.ClearChanged();
            }
        }
    }
}
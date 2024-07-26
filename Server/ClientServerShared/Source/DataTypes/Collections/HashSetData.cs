using System.Linq;

namespace DataTypes.Collections
{
    public class HashSetData<TValue> : IntKeyDictionaryData<TValue>
        where TValue : IData, new()
    {
        private readonly int _maxSize;
        
        public int AddItem(TValue data)
        {
            var index = data.GetHashCode();

            if (Count > _maxSize)
            {
                var first = this.First();
                Remove(first.Key);
            }
            
            Add(index, data);
            return index;
        }

        public HashSetData(int maxSize = int.MaxValue)
        {
            _maxSize = maxSize;
        }
    }

}
using DataTypes.Fields;

namespace DataTypes.Collections
{
    public class ChatData : HashSetData<StringDataField>
    {
        private int _counter;

        private const int MaxCount = 20;

        public void AddMessage(StringDataField data)
        {
            var key = (_counter + 1) % int.MaxValue;

            if (key > MaxCount)
            {
                var removeKey = _counter - MaxCount;
                Remove(removeKey);
            }
            
            _counter = key;
            Add(_counter, data);
        }
    }
}
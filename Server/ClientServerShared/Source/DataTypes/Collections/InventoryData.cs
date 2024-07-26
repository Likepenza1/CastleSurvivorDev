using System.Linq;

namespace DataTypes.Collections
{
    public class InventoryData<TValue> : IntKeyDictionaryData<TValue> 
        where TValue : InventorySlotData, new()
    {
        public bool TryGetFree(out TValue slot)
        {
            if (Count == 0)
            {
                slot = null;
                return false;
            }
            
            slot = this.FirstOrDefault(item => item.Value.IsFree).Value;
            return slot != null;
        }
        
        public bool TryGetItem(string id, out TValue slot)
        {
            if (Count == 0)
            {
                slot = null;
                return false;
            }
            
            slot = this.FirstOrDefault(item => item.Value.ItemId.Value == id).Value;
            return slot != null;
        }
        
        public InventoryData(int defaultSlotsCount = 0)
        {
            for (int i = 0; i < defaultSlotsCount; i++)
            {
                Add(i, new TValue());
            }
        }
    }
}
using DataTypes.Fields;

namespace DataTypes.Collections
{
    public abstract class InventorySlotData : Data
    {
        public bool IsFree => string.IsNullOrEmpty(ItemId.Value);
        
        public readonly StringDataField ItemId = new();
        
        public InventorySlotData()
        {
            AddData(ItemId);
        }
    }
}
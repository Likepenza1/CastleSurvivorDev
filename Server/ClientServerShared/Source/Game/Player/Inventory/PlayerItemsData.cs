using DataTypes;

namespace Game.Player.Inventory
{
    public class PlayerItemsData : Data
    {
        public readonly PlayerEquipmentData Equipment = new();
        public readonly PlayerEquipmentData Inventory = new();
        
        public PlayerItemsData()
        {
            AddData(Equipment);
            AddData(Inventory);
        }
    }
}
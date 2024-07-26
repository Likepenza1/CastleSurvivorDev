using DataTypes;
using DataTypes.Fields;
using Game.Player.Resource;
using Game.Player.Upgrades;

namespace Game.Player
{
    public class PlayerData : Data
    {
        public readonly StringDataField Id = new();
        public readonly IntDataField StageLevel = new();
        public readonly PlayerAppearanceData Appearance = new();
        public readonly ResourcesData Resources = new();
        public readonly PlayerUpgradesData Upgrades = new();
        public readonly BoolDataField PlayedPreviously = new();

        public PlayerData()
        {
            AddData(Id);
            AddData(StageLevel);
            AddData(Appearance);
            AddData(Resources);
            AddData(Upgrades);
            AddData(PlayedPreviously);
        }
    }
}
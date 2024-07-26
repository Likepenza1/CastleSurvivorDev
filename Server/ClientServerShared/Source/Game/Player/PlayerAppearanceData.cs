using DataTypes;
using DataTypes.Fields;

namespace Game.Player
{
    public class PlayerAppearanceData : Data
    {
        public readonly BoolDataField Gender = new();
        public readonly IntDataField HairIndex = new();
        public readonly Vector3DataField HairColor = new();
        public readonly Vector3DataField EyesColor = new();

        public PlayerAppearanceData()
        {
            AddData(Gender);
            AddData(HairIndex);
            AddData(HairColor);
            AddData(EyesColor);
        }
    }
}
using System;
using Descriptions.Generated;
using Descriptions.Types;
using MessagePack;

namespace Descriptions.Upgrades
{
    [MessagePackObject(true)]
    [Serializable]
    public class UpgradeLevelDescription
    {
        public ResourceReference Resource = new() { Id = ResourceIds.Gold };
        public long UpgradePrice;
        public float Value;
    }
}
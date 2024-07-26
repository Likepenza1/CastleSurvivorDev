using Models.Descriptions;
using Models.References.Base;

namespace GameRules.Upgrade
{
    public abstract partial class UpgradeDescriptionGenerator<T> : BaseDescriptionsGenerator<T> where T : IDescription
    {
        protected abstract void add(string id, TODO);
    }
}
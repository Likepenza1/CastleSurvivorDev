namespace Descriptions.Core
{
    public class JsonDescriptionGenerator<T> : BaseJsonDescriptionGenerator<T>
        where T : DescriptionWithId
    {
        protected override string SubPath { get; }

        public JsonDescriptionGenerator(string subPath)
        {
            SubPath = subPath;
        }

        protected override (string, T) GetDescription(T description)
        {
            return (description.Id, description);
        }
    }
}
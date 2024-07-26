namespace DataTypes
{
    public interface IData
    {
        bool IsDirty { get; }
        IDataDiff GetDiff();
        IDataDiff GetWhole();
        void Apply(IDataDiff diff);
        void ClearChanged();
    }
}
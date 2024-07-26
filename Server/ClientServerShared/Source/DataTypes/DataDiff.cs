using MessagePack;

namespace DataTypes
{
    [MessagePackObject]
    public class DataDiff : IDataDiff
    {
        [Key(0)]
        public IDataDiff[] Data { get; }

        public DataDiff(IDataDiff[] data)
        {
            Data = data;
        }
    }
}
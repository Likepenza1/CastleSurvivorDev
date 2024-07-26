namespace Network.Serialization
{
    public abstract class BaseSerializer
    {
        public abstract void Init();
        public abstract T Deserialize<T>(byte[] data);
        public abstract byte[] Serialize<T>(T value);
    }

}
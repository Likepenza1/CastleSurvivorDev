using System.Collections.Generic;

namespace Network.Processor
{
    public class DataReceiver
    {
        private readonly Queue<byte[]> _data = new();

        public void Put(byte[] data)
        {
            _data.Enqueue(data);
        }

        public byte[] Get()
        {
            return _data.Dequeue();
        }

        public bool HasUnprocessed => _data.Count > 0;
    }
}
using System.IO;
using Core.Awaiters;
using Core.Awaiters.Time;
using Core.Controllers;
using CoreExtension;
using DataTypes;
using MessagePack;

namespace Server.ServerCore.Save
{
    public abstract class BaseDataSaveController<TData> : IController
    where TData : Data
    {
        private readonly string _id;
        private readonly TData _data;
        
        private readonly float _minDelay;
        private readonly float _maxDelay;
        
        private const string DataPath = "Saves/{0}.save";
        private const string DataDirectory = "Saves/";
        
        private readonly AwaitComponent _awaitComponent = new();
        private bool _initialized;
        private string _path;

        protected BaseDataSaveController(string id, TData data, float minDelay, float maxDelay)
        {
            _id = id;
            _data = data;
            _minDelay = minDelay;
            _maxDelay = maxDelay;
        }

        public void Deactivate()
        {
            _awaitComponent.Dispose();

            if (_initialized)
            {
                var whole = _data.GetWhole();
                var writeBytes = MessagePackSerializer.Serialize(whole);
                File.WriteAllBytes(_path, writeBytes);
            }
        }

        public async void Activate()
        {
            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }
            
            _path = string.Format(DataPath, _id);
            var fileExists = File.Exists(_path);

            if (fileExists)
            {
                var bytes = await File.ReadAllBytesAsync(_path);
                var dataWhole = MessagePackSerializer.Deserialize<IDataDiff>(bytes);
                _data.Apply(dataWhole);
            }

            _initialized = true;
            OnCompleteLoad();

            while (true)
            {
                var waitTime = RandomExtensions.InRange(_minDelay, _maxDelay);
                await _awaitComponent.WaitForSeconds(waitTime);

                var whole = _data.GetWhole();
                var writeBytes = MessagePackSerializer.Serialize(whole);
                BeforeSave();
                await File.WriteAllBytesAsync(_path, writeBytes);
                OnSave();
            }
        }

        protected abstract void OnCompleteLoad();
        protected abstract void BeforeSave();
        protected abstract void OnSave();
    }
}
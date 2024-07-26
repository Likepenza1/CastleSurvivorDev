using Core.Controllers;

namespace Server.ServerLogic.Base
{
    public abstract class BaseCollectionController<T> : IController
    {
        private readonly IActiveCollection<T> _collection;

        private readonly DictionaryControllerCollection<T> _controllers = new();

        protected BaseCollectionController(IActiveCollection<T> collection)
        {
            _collection = collection;

        }

        public void Deactivate()
        {
            _collection.Added.Called -= OnAdded;
            
            _controllers.Deactivate();
            _controllers.Clear();
            _collection.Removed.Called -= OnRemoved;
        }

        public void Activate()
        {
            _collection.Added.Called += OnAdded;
            _collection.Removed.Called += OnRemoved;

            foreach (var item in _collection.GetAll())
            {
                Add(item);
            }
        }

        private void OnRemoved(T value)
        {
            _controllers.Remove(value);
        }

        private void OnAdded(T value)
        {
            Add(value);
        }

        private void Add(T item)
        {
            var controller = CreateController(item);
            _controllers.Add(item, controller);
        }

        protected abstract IController CreateController(T model);
    }
}
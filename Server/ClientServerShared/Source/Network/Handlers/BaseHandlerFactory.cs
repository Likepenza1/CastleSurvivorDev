using System;
using System.Collections.Generic;
using Network.Messages;

namespace Network.Handlers
{
    public abstract class BaseHandlerFactory
    {
        private readonly Dictionary<Type, IMessageHandler> _handlers = new();

        public void Init()
        {
            foreach (var handler in CreateHandlers())
            {
                _handlers.Add(handler.type, handler.handler);
            }
        }

        public abstract IEnumerable<(Type type, IMessageHandler handler)> CreateHandlers();

        public bool TryGetHandler(IMessage message, out IMessageHandler handler)
        {
            var messageType = message.GetType();
            return _handlers.TryGetValue(messageType, out handler);
        }
    }
}
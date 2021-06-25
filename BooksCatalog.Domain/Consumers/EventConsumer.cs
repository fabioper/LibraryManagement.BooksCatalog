using BooksCatalog.Domain.Interfaces;

namespace BooksCatalog.Domain.Consumers
{
    public abstract class EventConsumer<TMessage> : IEventConsumer<TMessage>
    {
        private readonly string _queueName;

        public EventConsumer(string queueName)
        {
            _queueName = queueName;
        }

        public abstract void HandleMessage(TMessage message);
    }
}
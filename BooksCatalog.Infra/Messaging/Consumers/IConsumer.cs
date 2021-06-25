namespace BooksCatalog.Infra.Messaging.Consumers
{
    public interface IConsumer<TMessage>
    {
        void HandleMessage(TMessage message);
    }
}
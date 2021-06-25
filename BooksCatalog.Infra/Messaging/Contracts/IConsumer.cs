namespace BooksCatalog.Infra.Messaging.Contracts
{
    public interface IConsumer<TMessage>
    {
        void HandleMessage(TMessage message);
    }
}
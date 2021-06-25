namespace BooksCatalog.Infra.Messaging.Contracts
{
    public interface IConsumer<in TMessage>
    {
        void HandleMessage(TMessage message);
    }
}
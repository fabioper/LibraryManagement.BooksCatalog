namespace BooksCatalog.Domain.Interfaces
{
    public interface IEventConsumer<TMessage>
    {
        void HandleMessage(TMessage message);
    }
}
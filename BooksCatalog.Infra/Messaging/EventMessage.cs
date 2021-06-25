namespace BooksCatalog.Infra.Messaging
{
    public abstract class EventMessage
    {
        public abstract string QueueName();
    }
}
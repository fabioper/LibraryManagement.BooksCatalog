using System.Threading.Tasks;

namespace BooksCatalog.Infra.Messaging.Contracts
{
    public interface IServiceBus
    {
        Task Publish(EventMessage message);
    }
}
using System.Text;
using System.Threading.Tasks;
using BooksCatalog.Infra.Messaging.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BooksCatalog.Infra.Messaging
{
    public class ServiceBus : IServiceBus
    {
        public Task Publish(EventMessage message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var queue = message.QueueName();
            channel.QueueDeclare(queue, false, false, false, null);

            var serializedMessage =  JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(serializedMessage);
            
            channel.BasicPublish("", queue, false, null, body);

            return Task.CompletedTask;
        }
    }
}
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BooksCatalog.Infra.Messaging.Consumers;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BooksCatalog.API.Consumers
{
    public abstract class Consumer<TMessage> : BackgroundService, IConsumer<TMessage>
    {
        private readonly string _queueName;
        private IConnection _connection;
        private IModel _channel;

        protected Consumer(string queueName)
        {
            _queueName = queueName;
            Initialize();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (_, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var message = JsonConvert.DeserializeObject<TMessage>(content);

                HandleMessage(message);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queueName, false, consumer);

            return Task.CompletedTask;
        }

        private void Initialize()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_queueName, false, false, false, null);
        }

        public abstract void HandleMessage(TMessage message);
    }
}
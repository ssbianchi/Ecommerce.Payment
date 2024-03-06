using System.Text.Json;
using System.Text;
using RabbitMQ.Client;

namespace Ecommerce.Payment.Application.RabbitRequest
{
    public class RabbitRequestService : IRabbitRequestService
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "paymentQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "paymentQueue",
                                 basicProperties: null,
                                 body: body);

        }
    }
}

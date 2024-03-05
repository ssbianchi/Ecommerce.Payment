using Ecommerce.Payment.CrossCutting.Rabbit;
using Ecommerce.Payment.Rabbit.Consumer.WebApi.Payment;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Ecommerce.Payment.Rabbit.Consumer
{
    public class Program
    {
        private static IPaymentAPI _paymentAPI;
        static void Main(string[] args)
        {
            if (_paymentAPI == null)
                _paymentAPI = new PaymentAPI();

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "orderQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body);

                    if (json == "true")
                        return;

                    RabbitMenssage message = JsonSerializer.Deserialize<RabbitMenssage>(json);

                    System.Threading.Thread.Sleep(1000);

                    var api = _paymentAPI.SavePayment(message.OrderSessionId, message.Amount);

                    Console.WriteLine($"OrderSessionId: {message.OrderSessionId}; Amount={message.Amount}");
                };
                channel.BasicConsume(queue: "orderQueue",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}

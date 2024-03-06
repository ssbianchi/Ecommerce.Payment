namespace Ecommerce.Payment.Application.RabbitRequest
{
    public interface IRabbitRequestService
    {
        void SendMessage<T>(T message);
    }
}

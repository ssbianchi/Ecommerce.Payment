using Ecommerce.Payment.CrossCutting.Entity;

namespace Ecommerce.Payment.Application.Payment.Dto
{
    public class PaymentDto : OperationEntity<int>
    {
        public string Nome { get; set; }
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

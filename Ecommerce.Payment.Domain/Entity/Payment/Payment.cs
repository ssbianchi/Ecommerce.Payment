using Ecommerce.Payment.CrossCutting.Entity;

namespace Ecommerce.Payment.Domain.Entity.Payment
{
    public class Payment : Entity<int>
    {
        public int OrderSessionId { get; set; }
        public int StatusId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

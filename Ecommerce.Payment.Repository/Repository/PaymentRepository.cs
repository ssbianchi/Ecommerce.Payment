using Ecommerce.Payment.Domain.Entity.Payment.Repository;
using Ecommerce.Payment.Repository.Context;

namespace Ecommerce.Payment.Repository.Repository
{
    public class PaymentRepository : UnitOfWork<Ecommerce.Payment.Domain.Entity.Payment.Payment>, IPaymentRepository
    {
        public PaymentRepository(EcommerceContext context) : base(context)
        {
        }
    }
}

using Ecommerce.Payment.Application.Payment.Dto;
using Ecommerce.Payment.Domain.Entity.Readonly.Dapper.Payment;

namespace Ecommerce.Payment.Application.Payment.Profile
{
    public class PaymentProfile : AutoMapper.Profile
    {
        public PaymentProfile()
        {
            CreateMap<Ecommerce.Payment.Domain.Entity.Payment.Payment, PaymentDto>().ReverseMap();
            CreateMap<DapperPayment, PaymentDto>().ReverseMap();
        }
    }
}

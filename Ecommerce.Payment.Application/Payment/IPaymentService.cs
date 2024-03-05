using Ecommerce.Payment.Application.Payment.Dto;

namespace Ecommerce.Payment.Application.Payment
{
    public interface IPaymentService
    {
        Task<PaymentDto> GetPayment(int PaymentId);
        Task<List<PaymentDto>> GetAllPayments();
        Task<PaymentDto> SavePayment(int orderSessionId, double amount);
        Task<bool> DeletePayment(int PaymentdId);
    }
}


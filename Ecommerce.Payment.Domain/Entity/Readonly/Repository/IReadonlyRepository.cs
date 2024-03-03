using Ecommerce.Payment.Domain.Entity.Readonly.Dapper.Payment;

namespace Ecommerce.Payment.Domain.Entity.Readonly.Repository
{
    public interface IReadonlyRepository
    {
        #region Payment
        Task<IEnumerable<DapperPayment>> GetAllPayment();
        #endregion
    }
}

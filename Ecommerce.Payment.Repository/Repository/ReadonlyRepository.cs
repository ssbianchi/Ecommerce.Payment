using Ecommerce.Payment.Domain.Entity.Readonly.Dapper.Payment;
using Ecommerce.Payment.Domain.Entity.Readonly.Repository;
using Ecommerce.Payment.Repository.Context;
using Ecommerce.Payment.Repository.Repository.Options;
using Microsoft.Extensions.Options;

namespace Ecommerce.Payment.Repository.Repository
{
    public class ReadonlyRepository : UnitOfWorkQuery, IReadonlyRepository
    {
        public ReadonlyRepository(IOptions<ConnectionStringOptions> options) : base(options.Value.ConnectionString)
        {

        }

        #region Payment
        public async Task<IEnumerable<DapperPayment>> GetAllPayment()
        {
            var sql = @"
Select Id
     , OrderSessionId
     , StatusId
     , Amount
     , CreatedAt
  From Payments";

            //var result = await QueryAsync<DapperPayment>(sql, new { Id = PaymentId });
            var result = await QueryAsync<DapperPayment>(sql);
            return result;
        }
        #endregion
    }
}

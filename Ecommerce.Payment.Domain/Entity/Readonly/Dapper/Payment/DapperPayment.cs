namespace Ecommerce.Payment.Domain.Entity.Readonly.Dapper.Payment
{
    public class DapperPayment
    {
        public int Id { get; set; }
        public int OrderSessionId { get; set; }
        public int StatusId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt{ get; set; }
    }
}

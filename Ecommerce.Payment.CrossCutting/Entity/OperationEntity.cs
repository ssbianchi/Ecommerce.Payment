using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Payment.CrossCutting.Entity
{
    public abstract class OperationEntity<T> : Entity<T>
    {
        [NotMapped]
        public virtual int? OperationId { get; set; }
    }
}

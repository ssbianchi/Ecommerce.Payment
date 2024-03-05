using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Payment.Repository.Mapping.Payment
{
    public class PaymentMapping : IEntityTypeConfiguration<Ecommerce.Payment.Domain.Entity.Payment.Payment>
    {
        public void Configure(EntityTypeBuilder<Ecommerce.Payment.Domain.Entity.Payment.Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.OrderSessionId).IsRequired().HasColumnName("OrderSessionId");
            builder.Property(x => x.StatusId).IsRequired().HasColumnName("StatusId");
            builder.Property(x => x.Amount).IsRequired().HasColumnName("Amount");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnName("CreatedAt");
        }
    }
}

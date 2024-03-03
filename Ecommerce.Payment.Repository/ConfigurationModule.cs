using Ecommerce.Payment.Domain.Entity.Payment.Repository;
using Ecommerce.Payment.Domain.Entity.Readonly.Repository;
using Ecommerce.Payment.Repository.Context;
using Ecommerce.Payment.Repository.Repository;
using Ecommerce.Payment.Repository.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Payment.Repository
{
    public static class ConfigurationModule
    {
        public static void RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EcommerceContext>(c =>
            {
                connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Ecommerce_Payment;Trusted_Connection=True;";
                c.UseSqlServer(connectionString);
            });

            //Use for Dapper
            services.Configure<ConnectionStringOptions>(c =>
            {
                c.ConnectionString = connectionString;
            });

            services.AddScoped<IReadonlyRepository, ReadonlyRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

        }

    }
}

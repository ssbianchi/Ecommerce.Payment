using Ecommerce.Payment.Application.Payment;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Payment.Application
{
    public static class ConfigurationModule
    {
        public static void RegisterApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ConfigurationModule).Assembly);

            service.AddScoped<IPaymentService, PaymentService>();
        }
    }
}

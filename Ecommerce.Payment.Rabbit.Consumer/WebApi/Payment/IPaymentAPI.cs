using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Payment.Rabbit.Consumer.WebApi.Payment
{
    public interface IPaymentAPI
    {
        Task<bool> SavePayment(int orderSessionId, double amount);
    }
}

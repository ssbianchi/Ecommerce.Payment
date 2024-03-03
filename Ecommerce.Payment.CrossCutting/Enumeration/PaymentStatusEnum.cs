using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Payment.CrossCutting.Enumeration
{
    public enum PaymentStatusEnum
    {
        NotSet = 0,
        InProcessing =1,
        Completed = 2,
        Refunded = 3
    }
}

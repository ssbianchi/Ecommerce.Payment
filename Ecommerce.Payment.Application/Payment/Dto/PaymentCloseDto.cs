using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Payment.Application.Payment.Dto
{
    public class PaymentCloseDto
    {
        public int OrderSessionId { get; set; }
        public int OrderSessionStatusId { get; set; }
    }
}

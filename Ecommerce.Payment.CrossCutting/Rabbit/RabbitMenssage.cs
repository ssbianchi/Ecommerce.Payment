using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Payment.CrossCutting.Rabbit
{
    public class RabbitMenssage
    {
        public int OrderSessionId { get; set; }
        public double Amount { get; set; }
    }
}

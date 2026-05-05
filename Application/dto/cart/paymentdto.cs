using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.cart
{
   public class paymentdto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}

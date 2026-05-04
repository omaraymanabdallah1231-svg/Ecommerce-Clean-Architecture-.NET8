using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.dto.cart
{
   public class checkout
    {
        public required Guid PaymentMethodid { get; set; }
        public required IEnumerable<processcart>carts { get; set; }
    }
}

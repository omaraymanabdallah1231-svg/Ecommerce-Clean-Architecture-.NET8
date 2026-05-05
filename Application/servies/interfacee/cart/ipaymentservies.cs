using ecommerce.application.dto.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.interfacee.cart
{
    public interface ipaymentservies
    {
        Task<IEnumerable<paymentdto>> GetPaymentdto();
    }
}

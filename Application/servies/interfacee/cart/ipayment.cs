using ecomerce.domain.entity;
using ecommerce.application.dto;
using ecommerce.application.dto.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.interfacee.cart
{
    public interface ipayment
    {
        Task<serviesresponce> pay(decimal totalamount, IEnumerable<Proudct> cartproudct, IEnumerable<processcart> cart);
    }
}

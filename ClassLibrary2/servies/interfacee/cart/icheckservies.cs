using ecomerce.domain.entity.cart;
using ecommerce.application.dto;
using ecommerce.application.dto.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.interfacee.cart
{
    public interface ICheckServies
    {
        Task<serviesresponce> SavecheckoutHistory(IEnumerable<createachive> checkouts);
        Task<serviesresponce> checkout(checkout check);


    }
}

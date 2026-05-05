using ecomerce.domain.entity.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.interfac.cart
{
    public interface Icart
    {
        Task<int> SavecheckoutHistory(IEnumerable<Achive> checkouts);
    }
}

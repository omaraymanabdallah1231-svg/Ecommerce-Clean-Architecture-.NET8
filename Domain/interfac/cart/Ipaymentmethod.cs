using ecomerce.domain.entity.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.interfac.cart
{
public  interface Ipaymentmethod
    {
      public  Task<IEnumerable<payment>> Getpaymentmetod();
    }
}

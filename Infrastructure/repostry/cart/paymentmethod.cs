using ecomerce.domain.interfac.cart;
using ecomerce.infrsutractor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecomerce.domain.entity.cart;
namespace ecomerce.infrsutractor.repostry.cart
{
  public  class paymentmethod : Ipaymentmethod
    {
        AppDbContext context;
        public paymentmethod(AppDbContext app)
        {
            context=app;
        }
        public async Task<IEnumerable<payment>> Getpaymentmetod()
        {
            return await context.payment.AsNoTracking().ToListAsync();
        }
    }
}

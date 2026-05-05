using ecomerce.domain.entity.cart;
using ecomerce.domain.interfac.cart;
using ecomerce.infrsutractor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.infrsutractor.repostry.cart
{
    public class cart : Icart
    {
        AppDbContext context;

        public cart(AppDbContext app)
        {
            context=app;
        }
        public async Task<int> SavecheckoutHistory(IEnumerable<Achive> checkouts)
        {
            context.checkoutachives.AddRange(checkouts);
            return await context.SaveChangesAsync();
        }
    }
}

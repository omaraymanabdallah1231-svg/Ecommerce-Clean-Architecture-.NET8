using AutoMapper;
using ecomerce.domain.entity;
using ecomerce.domain.entity.cart;
using ecomerce.domain.interfac;
using ecomerce.domain.interfac.cart;
using ecommerce.application.dto;
using ecommerce.application.dto.cart;
using ecommerce.application.servies.interfacee.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.implmentaion.cart
{
    public class CheckoutServies : ICheckServies
    {
        IMapper mapper;
         Icart cart;
        iGenraic<Proudct> proudctrepostry;
        ipaymentservies paymentservies;
        ipayment payment;


        public CheckoutServies(IMapper mapperr,Icart icart,iGenraic<Proudct>iGenraic,ipaymentservies ipaymentservies,ipayment ipayment)
        {
            mapper=mapperr;
            cart=icart;
            proudctrepostry=iGenraic;
            paymentservies=ipaymentservies;
            payment=ipayment;
        }
         
        public async Task<serviesresponce> checkout(checkout check)
        {
            var (proudcts, totalamount)=await GetTotalAmount(check.carts);
            var paymentmethod = await paymentservies.GetPaymentdto();
            if (check.PaymentMethodid==paymentmethod.FirstOrDefault()!.Id)
            {
                return await payment.pay(totalamount, proudcts, check.carts);
            }
            return new serviesresponce(false, "invalid payment");

        }

        public async Task<serviesresponce> SavecheckoutHistory(IEnumerable<createachive> checkouts)
        {
            var mapdata = mapper.Map<IEnumerable<Achive>>(checkouts);
          var result= await cart.SavecheckoutHistory(mapdata);
            return result>0 ? new serviesresponce(true, "checkout achived")
                : new serviesresponce(false, "error accueried in saving ");
             
        }
        private async Task<(IEnumerable<Proudct>, decimal)> GetTotalAmount(IEnumerable<processcart> cart)
        {

            if (!cart.Any()) return ([],0);

            var proudcts =await proudctrepostry.GetallAsync();
            if (!proudcts.Any()) return ([], 0);
            var cartproduct = cart.Select(cartitem => proudcts.FirstOrDefault(e => e.Id==cartitem.proudctid))
                .Where(a => a!=null).ToList();


           var totalamount = cart.Where(cartitem => cartproduct.Any(e => e.Id==cartitem.proudctid))
               .Sum(cartitem => cartitem.Quantity* cartproduct.First(e => e.Id==cartitem.proudctid)!.price);


            return (cartproduct!, totalamount);


        }
    }
}

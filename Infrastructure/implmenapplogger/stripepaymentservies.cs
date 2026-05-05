using ecomerce.domain.entity;
using ecommerce.application.dto;
using ecommerce.application.dto.cart;
using ecommerce.application.servies.interfacee.cart;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.infrsutractor.implmenapplogger
{
    class stripepaymentservies : ipayment
    {
        public async Task<serviesresponce> pay(decimal totalamount, IEnumerable<Proudct> cartproudct, IEnumerable<processcart> cart)
        {
            try
            {
                var listitem = new List<SessionLineItemOptions>();
                foreach (var item in cartproudct)
                {
                    var pQuantity = cart.FirstOrDefault(e => e.proudctid==item.Id);
                    listitem.Add(new SessionLineItemOptions
                    {
                        Quantity=pQuantity!.Quantity,


                        PriceData=new SessionLineItemPriceDataOptions
                        {
                            Currency="usd",
                            UnitAmount=(long)(item.price*100),


                            ProductData=new SessionLineItemPriceDataProductDataOptions
                            {
                                Description=item.Describition,
                                Name=item.Name,

                            },


                        },
                    });
                }
                var opation = new SessionCreateOptions // تجهيز الطلب 
                {
                    PaymentMethodTypes= ["usd"],
                    LineItems=listitem,
                    SuccessUrl="https://localhost:7167/payment-sucess",
                    CancelUrl="https://localhost:7167/payment-cancel"
                };

                var servies = new SessionService(); // ارسال الطلب
                Session session = await servies.CreateAsync(opation);
                return new serviesresponce(true, session.Url);
            }
            catch(Exception ex)
            {
                return new serviesresponce(false, ex.Message);
            }
        }
    }
}

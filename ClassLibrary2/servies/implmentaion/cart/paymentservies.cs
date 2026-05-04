using AutoMapper;
using ecomerce.domain.interfac.cart;
using ecommerce.application.dto.cart;
using ecommerce.application.servies.interfacee.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.implmentaion.cart
{

    public class paymentservies : ipaymentservies
    {
        Ipaymentmethod paymentmethod;
        IMapper mapper;
        public paymentservies(Ipaymentmethod ipaymentmethod,IMapper mapperr)
        {
            paymentmethod=ipaymentmethod;
            mapper=mapperr;

        }
        public async Task<IEnumerable<paymentdto>> GetPaymentdto()
        {
            var payment = await paymentmethod.Getpaymentmetod();
            if (!payment.Any()) return [];
            return mapper.Map<IEnumerable<paymentdto>>(payment);
        }
    }
}

using ecommerce.application.dto.cart;
using ecommerce.application.servies.interfacee.cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class paymentController : ControllerBase
    {
        ipaymentservies paymentservies;
        public paymentController(ipaymentservies ipaymentserviess)
        {
            paymentservies=ipaymentserviess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<paymentdto>>> getpaymentmethod()
        {
            var result= await paymentservies.GetPaymentdto();
            if (!result.Any()) return NotFound(result);
            return Ok(result);
        }


    }
}

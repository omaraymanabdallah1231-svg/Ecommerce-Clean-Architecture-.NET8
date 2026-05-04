using ecommerce.application.dto.cart;
using ecommerce.application.servies.interfacee.cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplicationapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cartController : ControllerBase
    {
        ICheckServies checkservies;
        public cartController(ICheckServies icheckservies)
        {
            checkservies=icheckservies;
        }
        [HttpPost("check")]
        public async Task<IActionResult> checkout(checkout checkout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await checkservies.checkout(checkout);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("savethecheck")]
        public async Task<IActionResult> savecheckout(IEnumerable<createachive> achive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await checkservies.SavecheckoutHistory(achive);
            return result.Success ? Ok(result) : BadRequest(result);
        }






    }
}

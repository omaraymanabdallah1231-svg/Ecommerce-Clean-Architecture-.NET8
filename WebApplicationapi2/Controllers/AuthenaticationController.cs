using ecommerce.application.dto.Identity;
using ecommerce.application.servies.interfacee.Authantication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplicationapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenaticationController : ControllerBase
    {
        IAuthentacionServies authentacionServies;
        public AuthenaticationController(IAuthentacionServies _authentacionServies)
        {
            authentacionServies=_authentacionServies;
        }
        [HttpPost("add")]
        public async Task<IActionResult> createuser(CreateUser user)
        {
         var result=await  authentacionServies.CreateUser(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> loginuser(LoginUser user)
        {
            var result = await authentacionServies.LoginUser(user);
            return result.success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("refreshtoken")]
        public async Task<IActionResult> revivetoken(string refreshtoken)
        {
            var result = await authentacionServies.ReviveToken(refreshtoken);
            return result.success ? Ok(result) : BadRequest(result);
        }
    }
}

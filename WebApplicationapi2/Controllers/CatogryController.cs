using ecommerce.application.dto;
using ecommerce.application.dto.catogry;
using ecommerce.application.servies.interfacee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplicationapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatogryController : ControllerBase
    {
        icatogryservies catogryservies;
        public CatogryController(icatogryservies _catogryservies)
        {
            catogryservies=_catogryservies;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var data = await catogryservies.GetallAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }
        [HttpGet("GetSignal{id}")]
        public async Task<IActionResult> GetSignal(Guid id)
        {
            var data = await catogryservies.GetByIdAsync(id);
            return data.Any() ? Ok(data) : NotFound(data);
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(createcatogry createcatogry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await catogryservies.addasynac(createcatogry);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> update(updatecatogry update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await catogryservies.updateasynac(update);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("dleate")]
        public async Task<IActionResult> dleate(Guid id)
        {
            var result = await catogryservies.dletaeasync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }


    }
}

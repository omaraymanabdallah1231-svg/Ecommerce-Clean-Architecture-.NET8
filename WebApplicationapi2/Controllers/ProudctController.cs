using ecommerce.application.dto.catogry;
using ecommerce.application.dto.product;
using ecommerce.application.servies.implmentaion;
using ecommerce.application.servies.interfacee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProudctController : ControllerBase
    {
        iproudcteservies proudcteservies;
        public ProudctController(iproudcteservies iproudcteservies)
        {
            proudcteservies=iproudcteservies;
            
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var data = await proudcteservies.GetallAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }
        [HttpGet("GetSignal{id}")]
        public async Task<IActionResult> GetSignal(Guid id)
        {
            var data = await proudcteservies.GetByIdAsync(id);
            return data.Any() ? Ok(data) : NotFound(data);
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(createproducts createproducts)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await proudcteservies.addasynac(createproducts);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> update(updateproducts update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await proudcteservies.updateasynac(update);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("dleate")]
        public async Task<IActionResult> dleate(Guid id)
        {
            var result = await proudcteservies.dletaeasync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

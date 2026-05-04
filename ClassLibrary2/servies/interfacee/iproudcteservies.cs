using ecommerce.application.dto;
using ecommerce.application.dto.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.interfacee
{
  public  interface iproudcteservies
    {
        Task<IEnumerable<Getproudct>> GetallAsync();
        Task<IEnumerable<Getproudct>> GetByIdAsync(Guid id);
        Task<serviesresponce> addasynac(createproducts create);
        Task<serviesresponce> updateasynac(updateproducts update);
        Task<serviesresponce> dletaeasync(Guid id);

    }
}

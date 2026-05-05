using ecommerce.application.dto.product;
using ecommerce.application.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.application.dto.catogry;

namespace ecommerce.application.servies.interfacee
{
    public interface icatogryservies
    {
        Task<IEnumerable<GetCatogry>> GetallAsync();
        Task<IEnumerable<GetCatogry>> GetByIdAsync(Guid id);
        Task<serviesresponce> addasynac(createcatogry create);
        Task<serviesresponce> updateasynac(updatecatogry update);
        Task<serviesresponce> dletaeasync(Guid id);

    }
}

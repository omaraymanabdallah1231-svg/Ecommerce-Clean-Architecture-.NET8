using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.interfac
{
   public interface iGenraic<Tentity>where Tentity :class
    {
        Task<IEnumerable<Tentity>> GetallAsync();
        Task<Tentity> GetByIdAsync(Guid id);
        Task<Tentity> addasynac(Tentity entity);
        Task<bool> updateasynac(Tentity tentity);
        Task<bool> dletaeasync(Guid id);


    }
}


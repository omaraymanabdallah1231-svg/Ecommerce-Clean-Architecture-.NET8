using ecomerce.domain.interfac;

using ecomerce.infrsutractor.Data;
using ecomerce.infrsutractor.Expation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.infrsutractor.repostry
{
   public class genaricrepostry<Tentity>(AppDbContext context) : iGenraic<Tentity> where Tentity :class
    {
        public   async Task<Tentity> addasynac(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
             
        }

        public async Task<bool> dletaeasync(Guid id)
        {
            var result = await context.Set<Tentity>().FindAsync(id);

            if (result == null)
                throw new ItemNotFoundException($"Item with id {id} not found");
              context.Set<Tentity>().Remove(result);
            await context.SaveChangesAsync();


            return true;

        }

        public async Task<IEnumerable<Tentity>> GetallAsync()
        {
            var result = await context.Set<Tentity>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Tentity> GetByIdAsync(Guid id)
        {
            var result = await context.Set<Tentity>().FindAsync(id);
            return result;

        }

        public async Task<bool> updateasynac(Tentity tentity)
        {

            context.Set<Tentity>().Update(tentity);

            var result = await context.SaveChangesAsync();

            return result > 0;



        }
    }
}

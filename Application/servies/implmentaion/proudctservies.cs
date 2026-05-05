using AutoMapper;
using ecomerce.domain.entity;
using ecomerce.domain.interfac;
using ecommerce.application.dto;
using ecommerce.application.dto.catogry;
using ecommerce.application.dto.product;
using ecommerce.application.servies.interfacee;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.implmentaion
{
    public class proudctservies(iGenraic<Proudct>genraic,IMapper mapper) : iproudcteservies
    {
       
        
        public async Task<serviesresponce> addasynac(createproducts create)
        {
            
            var mapeddata = mapper.Map<Proudct>(create);
            Proudct result = await genraic.addasynac(mapeddata);
            if (result == null)
                return new serviesresponce(false, "Failed to add product");
            return new serviesresponce(true,"sucess")
            {

            };
        }

        public async Task<serviesresponce> dletaeasync(Guid id)
        {
            var result = await genraic.dletaeasync(id);
            return result==true ? new serviesresponce(true, "proudcted is dleated") :
                new serviesresponce(false, "failed to dleated");
            
        }

        public async Task<IEnumerable<Getproudct>> GetallAsync()
        {
            var result = await genraic.GetallAsync();
            if (result==null)
            {
                return [];
            }
            
            return mapper.Map<IEnumerable<Getproudct>>(result);



        }


        public async Task<IEnumerable<Getproudct>> GetByIdAsync(Guid id)
        {
            Proudct result = await genraic.GetByIdAsync(id);
            if (result==null)
            
                new serviesresponce(false, "not found");

            return mapper.Map<IEnumerable<Getproudct>>(result);

        }

        public async Task<serviesresponce> updateasynac(updateproducts update)
        {
            var mapeddata = mapper.Map<Proudct>(update);

            var proudct = await genraic.updateasynac(mapeddata);
            return proudct ==true ? new serviesresponce(true, "sucess") : new serviesresponce(false, "failed");
        }
    }
}

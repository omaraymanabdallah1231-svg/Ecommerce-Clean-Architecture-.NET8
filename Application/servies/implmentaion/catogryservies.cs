using AutoMapper;
using ecomerce.domain.entity;
using ecomerce.domain.interfac;
using ecommerce.application.dto;
using ecommerce.application.dto.catogry;
using ecommerce.application.dto.product;
using ecommerce.application.servies.interfacee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.implmentaion
{
    public class catogryservies(iGenraic<Catogry> genraic, IMapper mapper) : icatogryservies
    {
        [HttpPost]
        public async Task<serviesresponce> addasynac(createcatogry create)
        {
            var mapeddata = mapper.Map<Catogry>(create);
            Catogry catogry = await genraic.addasynac(mapeddata);
            return new serviesresponce(true, "sucess")
           ;
        }
        [HttpDelete]
        public async Task<serviesresponce> dletaeasync(Guid id)
        {
            var result = await genraic.dletaeasync(id);
            return result ==true? new serviesresponce(true, "is dleated") :
                new serviesresponce(false, "failed");
        }
        [HttpDelete]
        public async Task<IEnumerable<GetCatogry>> GetallAsync()
        {
            var result = await genraic.GetallAsync();
            if (result==null)
            {
                return [];
            }
            return  mapper.Map<IEnumerable<GetCatogry>>(result);


        }
        [HttpGet]
        public async Task<IEnumerable<GetCatogry>> GetByIdAsync(Guid id)
        {
            Catogry result = await genraic.GetByIdAsync(id);
            if (result==null)

                new serviesresponce(false, "not found");

            return mapper.Map<IEnumerable<GetCatogry>>(result);


        }
        [HttpPut]
        public async Task<serviesresponce> updateasynac(updatecatogry update)
        {

            var mapdata = mapper.Map<Catogry>(update);
            var result = await genraic.updateasynac(mapdata);

            return new serviesresponce(true, "sucess update");
        }
    }
}

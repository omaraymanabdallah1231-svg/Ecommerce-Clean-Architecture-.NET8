using AutoMapper;
using ecommerce.application.dto.catogry;
using ecommerce.application.dto.product;
using ecomerce.domain.entity;
using ecomerce.domain.entity.identity;
using ecommerce.application.dto.Identity;
using ecommerce.application.dto.cart;
using ecomerce.domain.entity.cart;
namespace ecommerce.application.mapping
{
  public   class Mappingconfig:Profile
    {
        public  Mappingconfig()
        {
            CreateMap<LoginUser, AppUser>();
            CreateMap<CreateUser, AppUser>();
            CreateMap<createcatogry, Catogry>();
            CreateMap<createproducts, Proudct>();
            CreateMap<Catogry, GetCatogry>();
            CreateMap<Proudct, Getproudct>();
            CreateMap<payment, paymentdto>();
            CreateMap<Achive, createachive>();




        }
    }
}

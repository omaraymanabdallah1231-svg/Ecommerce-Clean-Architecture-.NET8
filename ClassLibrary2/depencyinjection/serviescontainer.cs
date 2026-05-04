using ecommerce.application.mapping;
using ecommerce.application.servies.implmentaion;
using ecommerce.application.servies.interfacee;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using ecommerce.application.Validation.Authentaication;
using ecommerce.application.dto.Identity;
using ecommerce.application.Validation.interfac;
using ecommerce.application.Validation.implmention;
using ecommerce.application.servies.interfacee.Authantication;
using Microsoft.AspNetCore.Authentication;
using ecommerce.application.servies.implmentaion.Autentaication;
using ecommerce.application.servies.interfacee.cart;
using ecommerce.application.servies.implmentaion.cart;

namespace ecommerce.application.depencyinjection
{
   public static class Serviescontainer
    {
        public static IServiceCollection addapplicationservies( this IServiceCollection services)
        {
           
            services.AddAutoMapper(cfg => { }, typeof(Mappingconfig).Assembly);
            services.AddScoped<iproudcteservies, proudctservies>();
            services.AddScoped<icatogryservies, catogryservies>();
            services.AddScoped<IvalidationServies, validationservies>();
            services.AddValidatorsFromAssemblyContaining<CreateUserValid>();
            services.AddScoped<IAuthentacionServies, Authentication>();
            services.AddScoped<ipaymentservies, paymentservies>();
            services.AddScoped<ICheckServies, CheckoutServies>();



            return services;
        }
    }
}

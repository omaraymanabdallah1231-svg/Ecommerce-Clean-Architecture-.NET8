using ecomerce.domain.entity;
using ecomerce.domain.interfac;
using ecomerce.infrsutractor.Data;
using ecomerce.infrsutractor.Middleware;
using ecomerce.infrsutractor.repostry;
using ecomerce.infrsutractor.servies;
using ecommerce.application.servies.interfacee.Logging;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ecomerce.domain.entity.identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ecomerce.domain.interfac.Authentaication;
using ecomerce.infrsutractor.repostry.Authentaction;
using ecomerce.domain.interfac.cart;
using ecomerce.infrsutractor.repostry.cart;
using ecomerce.infrsutractor.implmenapplogger;
using ecommerce.application.servies.interfacee.cart;
using Stripe;

namespace ecomerce.infrsutractor.indepencyincet
{
    public static class serviescontainer
    {
        public static IServiceCollection Addinfrustracuteservice(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opation => opation.UseSqlServer(config.GetConnectionString("defualt"),

                // حط ال migration في مكان الكلاس في مكان اسم البروجيكت 
                opation2 =>
                {
                    opation2.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                    opation2.EnableRetryOnFailure(); //"لو حصل فشل مؤقت في الاتصال بالداتا بيز، حاول تاني تلقائي"

                }
                ).UseExceptionProcessor(),
                ServiceLifetime.Scoped // حدد السيرفيز تعيش قد اي
            );
            
            services.AddScoped<iGenraic<Proudct>, genaricrepostry<Proudct>>(); // بقوله لو طلبت  ده تاخد ده 
            services.AddScoped<iGenraic<Catogry>, genaricrepostry<Catogry>>();
            services.AddScoped(typeof(IAppLogger<>), typeof(serilogloginadapter<>));
                       services.AddDefaultIdentity<AppUser>(opation =>
            {
                opation.SignIn.RequireConfirmedEmail=true;
                opation.Tokens.EmailConfirmationTokenProvider=TokenOptions.DefaultEmailProvider; //بيولد token لللايمال
                opation.Password.RequireNonAlphanumeric=false;
                opation.Password.RequiredLength=8;
                opation.Password.RequireLowercase=true;
                opation.Password.RequireUppercase=false;
                opation.Password.RequiredUniqueChars=1;
                opation.Password.RequireDigit=true;

            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


            services.AddAuthentication(opation =>
            {
                opation.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                opation.DefaultScheme=JwtBearerDefaults.AuthenticationScheme;
                opation.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opation =>
            {
                opation.SaveToken=false;
                opation.TokenValidationParameters=new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime=true,
                    ValidAudience=config["jwt:Audience"],
                    ValidIssuer=config["jwt:Issuer"],
                    ClockSkew=TimeSpan.Zero,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwt:key"]!))
                };
            });


            services.AddScoped<IUserMangment, Usermangment>();
            services.AddScoped<IRoleMangment, RoleMangment>();
            services.AddScoped<ItokenMangment, Tokenmangment>();
            services.AddScoped<Ipaymentmethod, paymentmethod>();
            services.AddScoped<ipayment, stripepaymentservies>();
            services.AddScoped<Icart, cart>();


            return services;
        }
      
        public static IApplicationBuilder useinfrastractorservies(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
            return builder;
        }
    }
}

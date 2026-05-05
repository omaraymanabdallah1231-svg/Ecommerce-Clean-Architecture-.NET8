using ecommerce.application.dto;
using ecommerce.application.dto.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.interfacee.Authantication
{
   public  interface IAuthentacionServies
    {
        Task<serviesresponce> CreateUser(CreateUser user);
        Task<LoginResponce> LoginUser(LoginUser login);
        Task<LoginResponce> ReviveToken(string Refreshtoken);

    }
}

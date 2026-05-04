using ecomerce.domain.entity.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.interfac.Authentaication
{
    public interface IUserMangment
    {
        Task<bool> CreateUser(AppUser appUser,string passowerd);
        Task<bool> LoginUser(string email, string passowerd);
        Task<AppUser> GetUserByEamil(string email);
        Task<AppUser> GetUserById(string id);
        Task<IEnumerable<AppUser?>> GetAllUser();
        Task<bool> RemoveUserByEamil(string email);
        Task<List<Claim>> GetUserclaims(string email);




    }
}

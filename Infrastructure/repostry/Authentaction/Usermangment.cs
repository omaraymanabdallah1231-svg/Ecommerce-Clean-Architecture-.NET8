using ecomerce.domain.entity.identity;
using ecomerce.domain.interfac.Authentaication;
using ecomerce.infrsutractor.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.infrsutractor.repostry.Authentaction
{
    public class Usermangment : IUserMangment
    {
        UserManager<AppUser> userManager;
        AppDbContext context;
        IRoleMangment roleMangment;
        public Usermangment(UserManager<AppUser>_userManager,IRoleMangment _roleMangment,AppDbContext appDb)
        {
            userManager=_userManager;
            roleMangment=_roleMangment;
            context=appDb;
        }
        public async Task<bool> CreateUser(AppUser appUser,string passowerd)
        {
            var user = await GetUserByEamil(appUser.Email!);
            if(user !=null)
            { 
                return false;
            }
           var result= await userManager.CreateAsync(appUser!, passowerd);
            if (result==null)
            {
                var x = result.Errors.Select(e => e.Description).ToList();
                Console.WriteLine(string.Join(",", x));
            }
            return result.Succeeded;
        }
        public async Task<AppUser> GetUserByEamil(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user==null) throw new Exception ("not found");
            return user;
        }
        public async Task<IEnumerable<AppUser?>> GetAllUser()
        {
            return await userManager.Users.ToListAsync();
        }

        

        public async Task<AppUser> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user==null) throw new Exception("User not found");
            else
            {
                return user;
            }
        }

        public async Task<List<Claim>> GetUserclaims(string email)
        {
            var user = await GetUserByEamil(email);
            if (user==null) throw new Exception("User not found");

            string? rolname = await roleMangment.GetUserRole(email);

            if (string.IsNullOrEmpty(rolname)) return new List<Claim>();

            List<Claim> claims = [
                new Claim("fullname", user!.fullname),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role,rolname)

                ];
            return claims;
        }

        public async Task<bool> LoginUser(string email,string passowerd)
        {
            var user = await GetUserByEamil(email);
            if(user ==null)
            {
                return false;
            }
            string? rolname = await roleMangment.GetUserRole(email);
            return await userManager.CheckPasswordAsync(user, passowerd);

        }

        public async Task<bool> RemoveUserByEamil(string email)
        {
            var user = await GetUserByEamil(email);
            if (user==null) return false;
            return (await userManager.DeleteAsync(user)).Succeeded;

           


        }
    }
}

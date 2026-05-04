using ecomerce.domain.entity.identity;
using ecomerce.domain.interfac.Authentaication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.infrsutractor.repostry.Authentaction
{
    public class RoleMangment : IRoleMangment
    {
        UserManager<AppUser> userManager;
        public RoleMangment(UserManager<AppUser>_userManager)
        {
            userManager=_userManager;
        }
        public async Task<bool> AddUserRole(AppUser appUser, string rolename)
        {
            if (appUser == null) return false;
           return (await userManager.AddToRoleAsync(appUser, rolename)).Succeeded;
        }
        public async Task<string?> GetUserRole(string useremail)
        {
            var user = await userManager.FindByEmailAsync(useremail);
            if (user == null) return null;
            return (await userManager.GetRolesAsync(user)).FirstOrDefault();
        }
    }
}

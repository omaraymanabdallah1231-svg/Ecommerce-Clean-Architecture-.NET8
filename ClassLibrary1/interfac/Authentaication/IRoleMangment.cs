using ecomerce.domain.entity.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.interfac.Authentaication
{
    public interface IRoleMangment
    {
        Task<string?> GetUserRole(string useremail);
        Task<bool> AddUserRole(AppUser appUser, string rolename);
    }
}

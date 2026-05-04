using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.domain.interfac.Authentaication
{
    public interface ItokenMangment
    {
        string GetRefreshToken();
        List<Claim> GetUserClaimFromToken(string email);
        Task<bool> VailidateRefreshToken(string Refreshtoken);
        Task<string> GetUserIdByRefreshToken(string Refreshtoken);
        Task<int> AddRefreshToken(string userid, string Refreshtoken);
        Task<bool> UpdateRefreshToken(string Userid, string Refreshtoken);
        string GenrateToken(List<Claim> claims);


    }
}

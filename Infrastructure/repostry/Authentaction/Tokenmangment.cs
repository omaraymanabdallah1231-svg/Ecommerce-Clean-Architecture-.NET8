using ecomerce.domain.entity.identity;
using ecomerce.domain.interfac.Authentaication;
using ecomerce.infrsutractor.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ecomerce.infrsutractor.repostry.Authentaction
{
    public class Tokenmangment : ItokenMangment
    {
        AppDbContext context;
        IConfiguration configuration;
        public Tokenmangment(AppDbContext _context,IConfiguration _configuration)
        {
            context=_context;
            configuration=_configuration;
        }
        public async Task<int> AddRefreshToken(string userid, string Refreshtoken)
        {
            context.refreshTokens.Add(new RefreshToken
            {
                UserId=userid,
                Token=Refreshtoken,

            });
            return await context.SaveChangesAsync();
        }

        public string GenrateToken(List<Claim> claims)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(2);


            var token = new JwtSecurityToken(

                issuer: configuration["jwt:Issur"]!,
                audience: configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        public string GetRefreshToken()
        {
            const int bytesize = 64;
            byte[] randombyte = new byte[bytesize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randombyte);
            }
            return Convert.ToBase64String(randombyte);
        }

        public List<Claim> GetUserClaimFromToken(string token)
        {
            var tokenhandler = new JwtSecurityTokenHandler(); // الميثود دي بتفك التوكين
            var jwttoken = tokenhandler.ReadJwtToken(token); //اتفك
            var claims = jwttoken.Claims;
            return claims.ToList();
        }

        public async Task<string> GetUserIdByRefreshToken(string Refreshtoken)
        {
            var result = await context.refreshTokens.FirstOrDefaultAsync(c => c.Token==Refreshtoken);
            if (result==null) throw new Exception("not found token");
            return result.UserId;
           

        }

        public async Task<bool> UpdateRefreshToken(string Userid, string Refreshtoken)
        {
            var user = await context.refreshTokens.FirstOrDefaultAsync(e => e.UserId==Userid);
            if (user==null) return false;

         user.Token=Refreshtoken;
            

              context.refreshTokens.Update(user);
            var result= await context.SaveChangesAsync();
            return result>0;
            
        }

        public async Task<bool> VailidateRefreshToken(string Refreshtoken)
        {
            var token = await context.refreshTokens.FirstOrDefaultAsync(e => e.Token==Refreshtoken);
            
            return token != null;
        }
    }
}

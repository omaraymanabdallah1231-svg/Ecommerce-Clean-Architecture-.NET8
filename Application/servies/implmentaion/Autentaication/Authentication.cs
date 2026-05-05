using AutoMapper;
using ecomerce.domain.entity.identity;
using ecomerce.domain.interfac.Authentaication;
using ecommerce.application.dto;
using ecommerce.application.dto.Identity;
using ecommerce.application.servies.interfacee.Authantication;
using ecommerce.application.servies.interfacee.Logging;
using ecommerce.application.Validation.interfac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.servies.implmentaion.Autentaication
{
    public class Authentication : IAuthentacionServies
    {
        IUserMangment userMangment;
        ItokenMangment tokenMangment;
        IRoleMangment roleMangment;
        IAppLogger<Authentication> logger;
        IMapper mapper;
        IValidator<CreateUser> createuservalid;
        IValidator<LoginUser> loginuservaild;
        IvalidationServies validationServies;



        public Authentication( IUserMangment _userMangment,ItokenMangment _tokenMangment,
            IRoleMangment _roleMangment,IAppLogger<Authentication>_logger,IMapper _mapper
            ,IValidator<CreateUser>_create,IValidator<LoginUser>_login,IvalidationServies _validationServies)
        {
            userMangment=_userMangment;
            roleMangment=_roleMangment;
            tokenMangment=_tokenMangment;
            logger=_logger;
            mapper=_mapper;
            createuservalid=_create;
            loginuservaild=_login;
            validationServies=_validationServies;
        }
        public async Task<serviesresponce> CreateUser(CreateUser user)
        {
            var validation = await validationServies.ValidationAsynac(user, createuservalid);

            if (!validation.Success) return validation;

            var map = mapper.Map<AppUser>(user);
            map.UserName=user.Email;
            var result = await userMangment.CreateUser(map, user.Passowerd);

            if (!result)
                return new serviesresponce(false,"email adress might be aleardy or accuer error");
            var _user = await userMangment.GetUserByEamil(map.Email);
            var users = await userMangment.GetAllUser();
            bool role = await roleMangment.AddUserRole(_user, users.Count()==0 ? "admin" : "user");
            if(!role)
            {
                bool remove = await userMangment.RemoveUserByEamil(user.Email);
                if(!remove)
                {
                    logger.LogErrors ( new Exception($"faild to remove email as {user.Email}"), "error accuerd");
                    return new serviesresponce(false, "daild to create account");
                }
            }
            return new serviesresponce(true, "succes to create account");






        }

        public async Task<LoginResponce> LoginUser(LoginUser login)
        {

            var validation = await validationServies.ValidationAsynac(login,loginuservaild);
            if (!validation.Success) return new LoginResponce(message: validation.Message);
            var map = mapper.Map<AppUser>(login);
            map.Email=login.Email;
            bool result = await userMangment.LoginUser(login.Email, login.Passowerd);
            if(!result) return new LoginResponce(message:"email not found or invalid credainl");
            var user = await userMangment.GetUserByEamil(login.Email);
            var claim = await userMangment.GetUserclaims(login.Email);
            string token =  tokenMangment.GenrateToken(claim); 
            string refreshtoken = tokenMangment.GetRefreshToken(); 

            int savetoken = await tokenMangment.AddRefreshToken(user.Id, refreshtoken);
            return savetoken <=0 ? new LoginResponce(message: "internal error accuerd") :
                new LoginResponce(true, "sucess", refreshtoken, token);


        }

        public async Task<LoginResponce> ReviveToken(string Refreshtoken)
        {

            var validationtoken = await tokenMangment.VailidateRefreshToken(Refreshtoken);

            if (!validationtoken) return new LoginResponce(message: "invalid token");

            var userid = await tokenMangment.GetUserIdByRefreshToken(Refreshtoken);
            AppUser? user = await userMangment.GetUserById(userid);
            if (user==null) return new LoginResponce(message:"UserNot Found");
            var claims = await userMangment.GetUserclaims(user.Email);
            var token =  tokenMangment.GenrateToken(claims);
            var refreshtoken = tokenMangment.GetRefreshToken();
            await tokenMangment.UpdateRefreshToken(userid, refreshtoken);
            return new LoginResponce(true, "success", refreshtoken, token);



        }
    }
}

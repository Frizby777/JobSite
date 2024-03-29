﻿using System;
using System.ComponentModel.DataAnnotations;
using JobSite.DAL;
using JobSite.DAL.Models;

namespace JobSite.BL.Auth
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthDAL authDal;
        private readonly IEncrypt encrypt;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthBL(IAuthDAL authDal, IEncrypt encrypt, IHttpContextAccessor httpContextAccessor) 
        {
            this.authDal = authDal;
            this.encrypt = encrypt;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateUser(UserModel user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Password = encrypt.HashPassword(user.Password, user.Salt);
            int id = await authDal.CreateUser(user);
            Login(id);
            return id;
        }
        public void Login(int id)
        {
            httpContextAccessor.HttpContext?.Session.SetInt32(AuthConstants.AUTH_SESSION_PARAM_NAME, id);
        }

        public async Task<int> Authenticate(string email, string password, bool rememberMe)
        {
            UserModel user = await authDal.GetUser(email);
            if (user.Password == encrypt.HashPassword(password, user.Salt))
            {
                Login(user.UserId ?? 0);
                return user.UserId ?? 0;
            }
            return 0;
        }

        public async Task<ValidationResult?> ValidateEmail(string email)
        {
            UserModel user = await authDal.GetUser(email);
            if(user.UserId != null)
                return new ValidationResult("Email уже существует");
            return null;
        }
    }
}

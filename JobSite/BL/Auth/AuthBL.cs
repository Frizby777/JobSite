using System;
using JobSite.DAL;
using JobSite.DAL.Models;

namespace JobSite.BL.Auth
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthDAL authDal;
        private readonly IEncrypt encrypt;
        public AuthBL(IAuthDAL authDal, IEncrypt encrypt)
        {
            this.authDal = authDal;
            this.encrypt = encrypt;
        }
        public async Task<int> CreateUser(UserModel user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Password = encrypt.HashPassword(user.Password, user.Salt);
            return await authDal.CreateUser(user);
        }
    }
}

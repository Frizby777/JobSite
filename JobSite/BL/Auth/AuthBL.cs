using System;
using JobSite.DAL;
using JobSite.DAL.Models;

namespace JobSite.BL.Auth
{
    public class AuthBL : IAuthBL
    {
        private readonly IAuthDAL authDal;
        public AuthBL(IAuthDAL authDal)
        {
            this.authDal = authDal;
        }
        public async Task<int> CreateUser(UserModel user)
        {
           return await authDal.CreateUser(user);
        }
    }
}

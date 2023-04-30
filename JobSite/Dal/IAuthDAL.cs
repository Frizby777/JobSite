using System;
using JobSite.DAL.Models;

namespace JobSite.DAL
{
    public interface IAuthDAL
    {
        Task<UserModel> GetUser(int id);
        Task<UserModel> GetUser(string email);
        Task<int> CreateUser(UserModel model);
    }
}

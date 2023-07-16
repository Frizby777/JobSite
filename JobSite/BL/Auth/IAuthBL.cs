using System.ComponentModel.DataAnnotations;

namespace JobSite.BL.Auth
{
    public interface IAuthBL
    {
        Task<int> CreateUser(JobSite.DAL.Models.UserModel user);
        Task<int> Authenticate(string email, string password, bool rememberMe);
        Task<ValidationResult?> ValidateEmail(string email);
    }
}

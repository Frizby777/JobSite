namespace JobSite.BL.Auth
{
    public interface IAuthBL
    {
        Task<int> CreateUser(JobSite.DAL.Models.UserModel user);
    }
}

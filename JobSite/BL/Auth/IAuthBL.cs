namespace JobSite.BL.Auth
{
    public interface IAuthBL
    {
        int CreateUser(JobSite.DAL.Models.UserModel user);
    }
}

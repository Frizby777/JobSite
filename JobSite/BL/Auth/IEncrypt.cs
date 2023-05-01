using System;

namespace JobSite.BL.Auth
{
    public interface IEncrypt
    {
        string HashPassword(string password, string salt);
    }
}

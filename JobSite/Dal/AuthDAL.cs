using System;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using JobSite.DAL.Models;

namespace JobSite.DAL
{
    public class AuthDAL : IAuthDAL
    {
        public async Task<UserModel> GetUser(int id)
        {
            using IDbConnection connection = new SqlConnection(DbHelper.ConnectionString);
            await connection.OpenAsync();

            return await connection.QueryFirstOrDefaultAsync<UserModel>(@"SELECT UserId, Email, Password, Salt, Status
                                                                            FROM AppUser 
                                                                            WHERE UserId = @id", new { id }) ?? new UserModel();
        }

        public async Task<UserModel> GetUser(string email)
        {
            using IDbConnection connection = new SqlConnection(DbHelper.ConnectionString);
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<UserModel>(@"SELECT UserId, Email, Password, Salt, Status
                                                                            FROM AppUser 
                                                                            WHERE Email = @email", new { email }) ?? new UserModel(); ;
        }

        public async Task<int> CreateUser(UserModel model)
        {
            using IDbConnection connection = new SqlConnection(DbHelper.ConnectionString);
            await connection.OpenAsync();
            string query = @"INSERT INTO AppUser (Email, Password, Salt, Status)
                                VALUES (@Email, @Password, @Salt, @Status)
                                SELECT SCOPE_IDENTITY()";
            return await connection.QuerySingleAsync<int>(query, model);
        }
    }
}

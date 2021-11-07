using _1_3_Bibliotekos_Panaudojimas.Entities;
using _1_3_Bibliotekos_Panaudojimas.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _1_3_Bibliotekos_Panaudojimas.Repository
{
    public class UserServiceRepo : IUserServiceRepository
    {

        private readonly string _connectionString;

        public UserServiceRepo(DbConnectionString dbConnectionString)
        {
            _connectionString = dbConnectionString.ConnectionString;
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity userEntity, CancellationToken cancellation)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellation);
            var inserted = await conn.QuerySingleAsync<UserEntity>("insert into Vartotojai" +
                "(Name,LastName,Phone,Email,Password)" +
                "values (@Name,@LastName,@Phone,@Email,@Password);" +
                "select * from Vartotojai where Id=SCOPE_IDENTITY();", userEntity);
            return inserted;
            
        }

        public async Task DeleteUserAsync(int id, CancellationToken cancellation)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellation);
            var entity = await conn.QuerySingleOrDefaultAsync<UserEntity>("delete from Vartotojai where Id=@Id", new { Id = id });
        }

        public async Task EditUserInfoAsync(UserEntity userEntity, CancellationToken cancellation)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellation);
            await conn.ExecuteAsync("Update Vartotojai " +
                "Set Name=@Name,LastName=@LastName,Phone=@Phone,Email=@Email,Password=@Password " +
                "where Id = @Id;", userEntity);
        }

        public async Task<List<UserEntity>> GetAllUsersAsync(CancellationToken cancellation)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellation);
            var entities = await conn.QueryAsync<UserEntity>("select * from Vartotojai");
            return entities.AsList();
        }

        public async Task<UserEntity> GetByIdAsync(int id, CancellationToken cancellation)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellation);
            var entity = await conn.QuerySingleOrDefaultAsync<UserEntity>("select * from Vartotojai where Id=@Id", new { Id = id });
            return entity;
        }
    }
}

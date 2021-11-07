using _1_3_Bibliotekos_Panaudojimas.Entities;
using _1_3_Bibliotekos_Panaudojimas.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidatorsUnitTests;
using ValidatorsUnitTests.Source.Validators;
using ValidatorsUnitTests.Source.Validators.ConfigurationModels;

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
            if (ValidateUserInfo(userEntity))
            {
                using var conn = new SqlConnection(_connectionString);
                await conn.OpenAsync(cancellation);
                var inserted = await conn.QuerySingleAsync<UserEntity>("insert into Vartotojai" +
                    "(Name,LastName,Phone,Email,Password)" +
                    "values (@Name,@LastName,@Phone,@Email,@Password);" +
                    "select * from Vartotojai where Id=SCOPE_IDENTITY();", userEntity);
                return inserted;
            }
            else return null;
            
        }

        public async Task DeleteUserAsync(int id, CancellationToken cancellation)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync(cancellation);
            var entity = await conn.QuerySingleOrDefaultAsync<UserEntity>("delete from Vartotojai where Id=@Id", new { Id = id });
        }

        public async Task EditUserInfoAsync(UserEntity userEntity, CancellationToken cancellation)
        {
            if (ValidateUserInfo(userEntity))
            {
                using var conn = new SqlConnection(_connectionString);
                await conn.OpenAsync(cancellation);
                await conn.ExecuteAsync("Update Vartotojai " +
                    "Set Name=@Name,LastName=@LastName,Phone=@Phone,Email=@Email,Password=@Password " +
                    "where Id = @Id;", userEntity);
            }
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

        public bool ValidateUserInfo(UserEntity userEntity)
        {
            Configuration.PasswordConfiguration = new Password
            {
                PasswordLength = 8,
                SpecialSymbols = new List<char> { '@', '!', '$' }
            };
            Configuration.EmailConfiguration = new Email
            {
                ValidTLD = new List<string> { "com", "lt", "ru" }
            };
            Configuration.PhoneNumberConfiguration = new Number
            {
                CountryCodes = new Dictionary<string, int>
                {
                    {"+227", 8},
                    {"+371", 8}
                }
            };

            if (PasswordValidator.IsPasswordValid(userEntity.Password) &&
                EmailValidator.IsEmailValid(userEntity.Email) &&
                PhoneNumberValidator.IsPhoneNumberValid(userEntity.Phone))
            {
                return true;
            }
            else throw new ArgumentException("Please check your input, some values didn't pass the validator!");
        }
    }
}

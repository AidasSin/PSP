using _1_3_Bibliotekos_Panaudojimas.Entities;
using _1_3_Bibliotekos_Panaudojimas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _1_3_Bibliotekos_Panaudojimas.Repository
{
    public interface IUserServiceRepository
    {
        public Task<List<UserEntity>> GetAllUsersAsync(CancellationToken cancellation);
        public Task<UserEntity> GetByIdAsync(int id, CancellationToken cancellation);
        public Task<UserEntity> CreateUserAsync(UserEntity userEntity, CancellationToken cancellation);
        public Task EditUserInfoAsync(UserEntity userEntity, CancellationToken cancellation);
        public Task DeleteUserAsync(int id, CancellationToken cancellation);

    }
}

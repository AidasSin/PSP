using System;
using Xunit;
using _1_3_Bibliotekos_Panaudojimas.Entities;
using _1_3_Bibliotekos_Panaudojimas.Repository;
using System.Threading.Tasks;
using _1_3_Bibliotekos_Panaudojimas;
using System.Threading;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace BibliotekosPanaudojimasTests
{
    public class UserServiceRepoShould
    {

        [Fact]
        public void GetUserById()
        {
            var _cancellation = new CancellationToken();

            var repo = new Mock<IUserServiceRepository>();

            repo.Setup(x => x.GetByIdAsync(1, _cancellation))
                .ReturnsAsync(new UserEntity
                {
                    Id = 1,
                    Name = "Testas",
                    LastName = "Testainis",
                    Email = "testainis@pastainis.lt",
                    Phone = "+37061111111",
                    Password = "Slaptazodis3000!"
                });

            var userRepo = repo.Object;

            var testUser = userRepo.GetByIdAsync(1, _cancellation);

            Assert.Equal(1, testUser.Id);
            Assert.NotEqual(2, testUser.Id);

        }
        [Fact]
        public void DeleteUserById()
        {
            var _cancellation = new CancellationToken();

            var repo = new Mock<IUserServiceRepository>();

            var user = new UserEntity
            {
                Id = 1,
                Name = "Testas",
                LastName = "Testainis",
                Email = "testainis@pastainis.lt",
                Phone = "+37061111111",
                Password = "Slaptazodis3000!"
            };

            repo.Setup(r => r.DeleteUserAsync(It.IsAny<int>(), _cancellation));

            var userRepo = repo.Object;

            userRepo.DeleteUserAsync(1, _cancellation);

            repo.Verify(r => r.DeleteUserAsync(1, _cancellation));

        }
        [Fact]
        public void UpdateUser()
        {
            var _cancellation = new CancellationToken();

            var repo = new Mock<IUserServiceRepository>();

            var user = new UserEntity
            {
                Id = 1,
                Name = "Testas",
                LastName = "Testainis",
                Email = "testainis@pastainis.lt",
                Phone = "+37061111111",
                Password = "Slaptazodis3000!"
            };

            repo.Setup(r => r.EditUserInfoAsync(It.IsAny<UserEntity>(), _cancellation));

            var userRepo = repo.Object;

            userRepo.EditUserInfoAsync(user, _cancellation);

            repo.Verify(r => r.EditUserInfoAsync(user, _cancellation));

        }
    }
}

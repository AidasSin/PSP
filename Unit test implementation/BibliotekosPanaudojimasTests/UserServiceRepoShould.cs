using System;
using Xunit;
using _1_3_Bibliotekos_Panaudojimas.Entities;
using _1_3_Bibliotekos_Panaudojimas.Repository;
using System.Threading.Tasks;
using _1_3_Bibliotekos_Panaudojimas;
using System.Threading;
using System.Collections.Generic;
using Moq;

namespace BibliotekosPanaudojimasTests
{
    public class UserServiceRepoShould
    {
        [Fact]
        public async Task Test1Async()
        {
            var userInMemoryDB = new List<UserEntity>
            {
                new UserEntity()
                {
                    Id = 1, Name = "Testas", LastName = "Testainis",
                    Email = "testainis@pastainis.lt", Phone = "+37061111111", Password = "Slaptazodis3000!"
                },
                new UserEntity()
                {
                    Id = 2, Name = "Kitastestas", LastName = "Kitastestainis",
                    Email = "testainis@pastainis2.lt", Phone = "+37061111112", Password = "Slaptazodis3002!"
                },
                new UserEntity()
                {
                    Id = 3, Name = "Darkitastestas", LastName = "Darkitastestainis",
                    Email = "dartestainis@pastainis2.lt", Phone = "+37061111113", Password = "Slaptazodis3003!"
                }
            };
            var repo = new Mock<IUserServiceRepository>();

        }
    }
}

using _1_3_Bibliotekos_Panaudojimas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_3_Bibliotekos_Panaudojimas.Models
{
    public static class UserExtensions
    {
        public static UserEntity ToEntity(this UserModel model)
        {
            return new UserEntity
            {
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Password = model.Password
            };
        }
        public static UserModel ToModel(this UserEntity entity )
        {
            return new UserModel
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Phone = entity.Phone,
                Email = entity.Email,
                Password = entity.Password
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_3_Bibliotekos_Panaudojimas.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

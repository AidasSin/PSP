using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_3_Bibliotekos_Panaudojimas
{
    public class DbConnectionString
    {
        public string ConnectionString { get; }
        public DbConnectionString(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("BibliotekaDB");
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentNullException("Connection string not found!");
        }
    }
}

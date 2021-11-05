using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BibliotekosPanaudojimas.Models;

namespace BibliotekosPanaudojimas.Data
{
    public class BibliotekosPanaudojimasContext : DbContext
    {
        public BibliotekosPanaudojimasContext (DbContextOptions<BibliotekosPanaudojimasContext> options)
            : base(options)
        {
        }

        public DbSet<BibliotekosPanaudojimas.Models.User> User { get; set; }
    }
}

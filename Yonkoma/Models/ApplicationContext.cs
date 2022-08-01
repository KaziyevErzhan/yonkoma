using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Yonkoma.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users> Account { get; set; }

        public DbSet<Manga> MangaPages { get; set; }
        public DbSet<OrderBy> Orders { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

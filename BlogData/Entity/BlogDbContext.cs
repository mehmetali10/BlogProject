using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogData.Entity
{
    public class BlogDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MEHMETALI10\\SQLEXPRESS;Database=BlogDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}

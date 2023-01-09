using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace BlogData.Entity
{
    public class BlogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
            optionsBuilder.UseMySql("server=quiself.cdanhxvffndf.us-east-1.rds.amazonaws.com;database=BlogDB;uid=admin;pwd=password123456789", serverVersion);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
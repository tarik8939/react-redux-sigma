using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class HouseDbContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                OpsBuilder = new DbContextOptionsBuilder<HouseDbContext>();
                OpsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = OpsBuilder.Options;
            }

            public DbContextOptionsBuilder<HouseDbContext> OpsBuilder { get; set; }
            public DbContextOptions<HouseDbContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<User>().HasData(
                new User {UserId = 1,Email = "test@test.com"}
            );
            builder.Entity<Post>().HasData(
                new Post {PostId = 1 ,UserId = 1, Title = "test title", Body = "test body"}
                );
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

    }
}

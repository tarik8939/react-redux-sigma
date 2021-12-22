using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.Data.SqlClient;
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
                new User {UserId = 1,Email = "test@test.com"});

            builder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1, UserId = 1, Title = "test title", Body = "test body"
                });

            builder.Entity<Category>().HasData( new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Sport"},
                new Category { CategoryId = 2, Name = "Science"},
                new Category { CategoryId = 3, Name = "Technology"},
                new Category { CategoryId = 4, Name = "Politics"},
            });

            builder.Entity<PostCategory>().HasData(new List<PostCategory>()
            {
                new PostCategory{PostId = 1, CategoryId = 2},
                new PostCategory{PostId = 1, CategoryId = 3},
            });

            builder.Entity<Document>().HasData(
                new Document {DocumentId = 1, PostId = 1});


            builder.Entity<PostCategory>()
                .HasKey(pc => new {pc.CategoryId, pc.PostId});

            builder.Entity<PostCategory>()
                .HasOne(pc => pc.Post)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(pc => pc.PostId);

            builder.Entity<PostCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(pc => pc.CategoryId);

            builder.Entity<Post>()
                .HasOne<Document>(p => p.Document)
                .WithOne(d => d.Post)
                .HasForeignKey<Document>(d => d.PostId);

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }
        
        public DbSet<Category> Category { get; set; }

        public DbSet<Document> Documents { get; set; }

    }
}

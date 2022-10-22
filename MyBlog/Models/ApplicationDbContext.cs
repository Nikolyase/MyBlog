using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public System.Data.Entity.DbSet<Article> Articles { get; set; }
        public System.Data.Entity.DbSet<Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<Tag> Tags { get; set; }
        //public System.Data.Entity.DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=Blog.db");
        //}        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbContextOptionsBuilder optionsBuilder) : base(options)
        {
            optionsBuilder.UseSqlite("Filename=Blog.db");
            Database.EnsureCreated();           
        }
    }
}

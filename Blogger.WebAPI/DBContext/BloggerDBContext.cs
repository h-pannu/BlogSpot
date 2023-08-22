using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Blogger.WebAPI.Data;
using Blogger.Shared.Models;
using AutoMapper;

namespace Blogger.WebAPI.DBContext
{
    public class BloggerDBContext : IdentityDbContext<Users>
    {
        public BloggerDBContext(DbContextOptions<BloggerDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can globally assign schema here
            modelBuilder.HasDefaultSchema("Identity");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}

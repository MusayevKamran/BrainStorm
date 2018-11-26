using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainStorm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrainStorm.Areas.Identity.Data
{
    public class BrainStormDbContext : IdentityDbContext<BrainStormUser>
    {
        public DbSet<BrainStormUser> BrainStormUser { get; set; }
        public DbSet<Article> Articles { get; set; }

        public BrainStormDbContext(DbContextOptions<BrainStormDbContext> options) : base(options) { }

        public DbSet<BrainStorm.Models.Comment> Comment { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<BrainStormUser>()
        //       .HasMany<Article>(a => a.Article)
        //       .WithOne(b => b.BrainStormUser)
        //       .HasPrincipalKey(c => c.Id);

        //    builder.Entity<BrainStormUser>()
        //        .HasMany<Comment>(a => a.Comment)
        //        .WithOne(b => b.BrainStormUser)
        //        .HasPrincipalKey(c => c.Id);

        //    builder.Entity<Article>()
        //        .HasMany<Comment>(a => a.Comment)
        //        .WithOne(b => b.Article)
        //        .HasPrincipalKey(c => c.Id);

        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}
    }
}

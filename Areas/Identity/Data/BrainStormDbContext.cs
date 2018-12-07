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
    public class BrainStormDbContext : IdentityDbContext<BrainStormUser, Role, Guid>
    {
        public DbSet<BrainStormUser> BrainStormUser { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public BrainStormDbContext(DbContextOptions<BrainStormDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BrainStormUser>()
               .HasMany<Article>(a => a.Article)
               .WithOne(b => b.BrainStormUser)
               .HasPrincipalKey(c => c.Id);

            builder.Entity<BrainStormUser>()
                .HasMany<Comment>(a => a.Comment)
                .WithOne(b => b.BrainStormUser)
                .HasPrincipalKey(c => c.Id);

            builder.Entity<Article>()
                .HasMany<Comment>(a => a.Comment)
                .WithOne(b => b.Article)
                .HasPrincipalKey(c => c.Id);

            base.OnModelCreating(builder);
        }
    }
}

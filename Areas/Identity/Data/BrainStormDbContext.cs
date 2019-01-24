using BrainStorm.Models;
using BrainStorm.Models.System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BrainStorm.Areas.Identity.Data
{
    public class BrainStormDbContext : IdentityDbContext<BrainStormUser, BrainStormRole, Guid>
    {
        public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<BrainStormUser> BrainStormUser { get; set; }


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


            builder.Entity<ArticleCategory>()
                .HasKey(a => new { a.ArticleId, a.CategoryId });

            builder.Entity<ArticleCategory>()
                .HasOne(a => a.Article)
                .WithMany(b => b.ArticleCategory)
                .HasForeignKey(a => a.ArticleId);

            builder.Entity<ArticleCategory>()
                .HasOne(a => a.Category)
                .WithMany(b => b.ArticleCategory)
                .HasForeignKey(a => a.CategoryId);

            base.OnModelCreating(builder);
        }
    }
}

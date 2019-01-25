using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class ArticleService : GenericService<Article>, IArticle
    {

        public ArticleService(BrainStormDbContext context) : base(context)
        { }

        public BrainStormDbContext context
        {
            get { return _context as BrainStormDbContext; }
        }

        public bool Exists(int id)
        {
            return context.Articles.Any(e => e.Id == id);
        }

        public async Task<List<Article>> GetBlogsAsync()
        {
            return await context.Articles
                     .Where(article => article.PostCategory == PostCategory.Blog)
                     .ToListAsync();
        }

        public async Task<List<Article>> GetTutorialsAsync()
        {
            return await context.Articles
                    .Where(article => article.PostCategory == PostCategory.Tutorial)
                    .ToListAsync();
        }

        public async Task<List<Article>> GetUserArticlesAsync(Guid Id)
        {
            return await context.Articles
                        .Where(m => m.BrainStormUser.Id == Id)
                        .ToListAsync();
        }

        public async Task<List<Article>> GetUserBlogsAsync(Guid Id)
        {
            return await context.Articles
                                .Where(article => article.BrainStormUser.Id == Id && article.PostCategory == PostCategory.Blog)
                                .ToListAsync();
        }

        public async Task<List<Article>> GetUserTutorialsAsync(Guid Id)
        {
            return await context.Articles
                                .Where(article => article.BrainStormUser.Id == Id && article.PostCategory == PostCategory.Tutorial)
                                .ToListAsync();
        }
    }
}

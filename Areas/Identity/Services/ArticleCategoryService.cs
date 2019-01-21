using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class ArticleCategoryService : IArticleCategory
    {
        BrainStormDbContext _context;
        public ArticleCategoryService(BrainStormDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArticleCategory>> findByArticleIDAsync(int id)
        {
            var articleCategory = await _context.ArticleCategories
                .Where(a => a.ArticleId == id).ToAsyncEnumerable().ToList();

            return articleCategory;
        }

        public async Task<List<ArticleCategory>> findByCategoryIDAsync(int id)
        {
            var articleCategory = await _context.ArticleCategories
                    .Where(a => a.CategoryId == id).ToAsyncEnumerable().ToList();

            return articleCategory;
        }
    }
}

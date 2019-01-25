using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class ArticleCategoryService : GenericService<ArticleCategory>, IArticleCategory
    {

        public ArticleCategoryService(BrainStormDbContext context) : base(context)
        { }

        public BrainStormDbContext context
        {
            get { return _context as BrainStormDbContext; }
        }

        public async Task<List<ArticleCategory>> getCategoryByArticleIdAsync(int id)
        {
            var articleCategory = await context.ArticleCategories
                .Where(a => a.ArticleId == id)
                .ToAsyncEnumerable().ToList();

            return articleCategory;
        }

        public async Task<List<ArticleCategory>> getArticleByCategoryIdAsync(int id)
        {
            var articleCategory = await context.ArticleCategories
                    .Where(a => a.CategoryId == id)
                    .ToAsyncEnumerable().ToList();

            return articleCategory;
        }

        public ArticleCategory updateArticleCategoryAsync(int articleId, int newCatId)
        {
            var category = context.ArticleCategories
                .Where(a => a.ArticleId == articleId);

            context.ArticleCategories.Remove(category.FirstOrDefault());

            var articleCategpry = new ArticleCategory() { ArticleId = articleId, CategoryId = newCatId };
            context.ArticleCategories.Add(articleCategpry);
           // _context.SaveChanges();

            return category.FirstOrDefault();
        }
    }
}

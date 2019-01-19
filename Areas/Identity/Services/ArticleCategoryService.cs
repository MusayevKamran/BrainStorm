using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using System.Linq;

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

        public ArticleCategory findByArticleID(int id)
        {
            var articleCategory = context.ArticleCategories.Where(a => a.ArticleId == id).FirstOrDefault();

            return articleCategory;
        }

        public ArticleCategory findByCategoryID(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

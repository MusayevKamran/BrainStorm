using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;


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

    }
}

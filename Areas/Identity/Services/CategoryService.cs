using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class CategoryService : GenericService<Category>, ICategory
    {
        public CategoryService(BrainStormDbContext context) : base(context)
        { }

        public BrainStormDbContext context
        {
            get { return _context as BrainStormDbContext; }
        }

        public bool Exists(int id)
        {
            return context.Category.Any(e => e.Id == id);
        }

        public async Task<ArticleCategory> GetCategoryByIdAsyncExtra(int? Id)
        {
            return await context.ArticleCategories
                .FirstOrDefaultAsync(m => m.CategoryId == Id);
        }
    }
}

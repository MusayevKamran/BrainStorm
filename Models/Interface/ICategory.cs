using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface ICategory : IGeneric<Category>
    {
        Task<ArticleCategory> GetCategoryByIdAsyncExtra(int? Id);
    }
}

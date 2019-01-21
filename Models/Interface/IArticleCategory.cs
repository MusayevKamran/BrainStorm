

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface IArticleCategory
    {
        Task<List<ArticleCategory>> getArticleByCategoryIdAsync(int id);
        Task<List<ArticleCategory>> getCategoriesByArticleIdAsync(int id);
    }
}

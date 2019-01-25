

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface IArticleCategory :IGeneric<ArticleCategory>
    {
        Task<List<ArticleCategory>> getArticleByCategoryIdAsync(int id);
        Task<List<ArticleCategory>> getCategoryByArticleIdAsync(int id);

        ArticleCategory updateArticleCategoryAsync(int articleId, int categoryId);
    }
}

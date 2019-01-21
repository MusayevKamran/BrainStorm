

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface IArticleCategory
    {
        Task<List<ArticleCategory>> findByArticleIDAsync(int id);
        Task<List<ArticleCategory>> findByCategoryIDAsync(int id);
    }
}

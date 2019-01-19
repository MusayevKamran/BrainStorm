

namespace BrainStorm.Models.Interface
{
    public interface IArticleCategory : IGeneric<ArticleCategory>
    {
        ArticleCategory findByArticleID(int id);
        ArticleCategory findByCategoryID(int id);
    }
}

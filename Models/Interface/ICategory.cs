using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface ICategory : IGeneric<Category>
    {
        bool Exists(int id);
        Task<ArticleCategory> GetCategoryByIdAsyncExtra(int? Id);
    }
}

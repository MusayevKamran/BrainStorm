using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface ICategory
    {
        List<Category> GetCategories();
        Task<List<Category>> GetCategoriesAsync();

        Category GetCategoryById(int? Id);
        Task<Category> GetCategoryByIdAsync(int? Id);

        Category CreateCategory(Category category);
        Task<Category> CreateCategoryAsync(Category category);

        Category UpdateCategory(int? Id, Category category);
        Task<Category> UpdateCategoryAsync(int? Id, Category category);

        void DeleteCategory(int? Id);
        Task DeleteCategoryConfirmedAsync(int? Id);
        Task<Category> DeleteCategoryAsync(int? Id);

        bool CategoryExists(int id);
    }
}

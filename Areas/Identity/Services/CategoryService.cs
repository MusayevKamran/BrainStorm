using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class CategoryService : ICategory
    {
        private readonly BrainStormDbContext _context;

        public CategoryService(BrainStormDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

        public Category Create(Category category)
        {
            category.Count = _context.Category.Any() == false ? 1 : _context.Category.Max(item => item.Count + 1);
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            category.Count = _context.Category.Any() == false ? 1 : _context.Category.Max(item => item.Count + 1);
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public void Delete(int? Id)
        {
            _context.Category.FirstOrDefault(m => m.Id == Id);
        }

        public async Task<Category> DeleteAsync(int? Id)
        {
            Category category = await _context.Category.FirstOrDefaultAsync(m => m.Id == Id);

            return category;
        }

        public async Task DeleteConfirmedAsync(int? Id)
        {
            var category = await _context.Category.FindAsync(Id);
            _context.Category.Remove(category);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public List<Category> GetAll()
        {
            var category = _context.Category.ToList();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var category = await _context.Category.ToListAsync();
            return category;
        }

        public Category GetById(int? Id)
        {
            var category = _context.Category.FirstOrDefault(m => m.Id == Id);
            return category;
        }

        public async Task<Category> GetByIdAsync(int? Id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(m => m.Id == Id);
            return category;
        }

        public async Task<ArticleCategory> GetCategoryByIdAsyncExtra(int? Id)
        {
            var category = await _context.ArticleCategories.FirstOrDefaultAsync(m => m.CategoryId == Id);
            return category;
        }

        public List<Category> GetCategoryListById(List<int> Id)
        {
            List<Category> categories = new List<Category>();

            foreach (var id in Id)
            {
                Category category = _context.Category.FirstOrDefault(m => m.Id == id);
                categories.Add(category);
            }

            return categories;
        }

        public async Task<List<Category>> GetCategoryListByIdAsync(List<int> Id)
        {
            List<Category> categories = new List<Category>();

            foreach (var id in Id)
            {
                Category category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);
                categories.Add(category);
            }

            return categories;
        }

        public Category Update(int? Id, Category category)
        {
            _context.Update(category);
            _context.SaveChanges();

            return category;
        }

        public async Task<Category> UpdateAsync(int? Id, Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}

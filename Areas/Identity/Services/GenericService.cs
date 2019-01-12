using BrainStorm.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class GenericService<T> : IGeneric<T> where T : class
    {
        protected readonly DbContext _context;

        public GenericService(DbContext context)
        {
            _context = context;
        }

        public void Create(T model)
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
        }

        public void DeleteConfirmed(T model)
        {
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public T GetById(int? Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public async Task<T> GetByIdAsync(int? Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public void Update(T model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}

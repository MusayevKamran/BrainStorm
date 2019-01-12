using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface IGeneric<T> where T : class
    {
        void Create(T model);
        void DeleteConfirmed(T model);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T GetById(int? Id);
        Task<T> GetByIdAsync(int? Id);
        void Update(T model);
    }
}

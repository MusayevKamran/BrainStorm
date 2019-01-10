using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    public interface IGeneric<T> where T : class
    {
        List<T> GetAll();
        Task<List<T>> GetAllAsync();  

        T GetById(int? Id);
        Task<T> GetByIdAsync(int? Id);

        T Create(T model);
        Task<T> CreateAsync(T model);

        T Update(int? Id, T model);
        Task<T> UpdateAsync(int? Id, T model);

        void Delete(int? Id);  
        Task<T> DeleteAsync(int? Id);
        Task DeleteConfirmedAsync(int? Id);

        bool Exists(int id);
    }
}

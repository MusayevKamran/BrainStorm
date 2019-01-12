using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BrainStorm.Models.Interface
{
    public interface IArticle : IGeneric<Article>
    {
        bool Exists(int id);
        Task<List<Article>> GetUserArticlesAsync(Guid Id);
    }
}

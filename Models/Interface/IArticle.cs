using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BrainStorm.Models.Interface
{
    public interface IArticle
    {
        List<Article> GetArticles();
        Task<List<Article>> GetArticlesAsync();
        Task<List<Article>> GetUserArticlesAsync(Guid Id);

        Article GetArticleById(int? Id);
        Task<Article> GetArticleByIdAsync(int? Id);

        Article CreateArticle(Article article);
        Task<Article> CreateArticleAsync(Article article);

        Article UpdateArticle(int? Id, Article article);
        Task<Article> UpdateArticleAsync(int? Id, Article article);

        void DeleteArticle(int? Id);
        Task DeleteArticleConfirmedAsync(int? Id);
        Task<Article> DeleteArticleAsync(int? Id);

        bool ArticleExists(int id);
    }
}

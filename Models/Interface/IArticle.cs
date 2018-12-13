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

        Article GetArticleById(Guid? Id);
        Task<Article> GetArticleByIdAsync(Guid? Id);

        Article CreateArticle(Article article);
        Task<Article> CreateArticleAsync(Article article);

        Article UpdateArticle(Guid? Id, Article article);
        Task<Article> UpdateArticleAsync(Guid? Id, Article article);

        void DeleteArticle(Guid? Id);
        Task DeleteArticleConfirmedAsync(Guid? Id);
        Task<Article> DeleteArticleAsync(Guid? Id);

        bool ArticleExists(Guid id);
    }
}

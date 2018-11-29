using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class ArticleService : IArticle
    {
        private readonly BrainStormDbContext _context;

        public ArticleService(BrainStormDbContext context)
        {
            _context = context;
        }

        public bool ArticleExists(Guid id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

        public Article CreateArticle(Article article)
        {
            article.Id = Guid.NewGuid();
            _context.Add(article);
            _context.SaveChanges();
            return article;
        }

        public async Task<Article> CreateArticleAsync(Article article)
        {
            article.Id = Guid.NewGuid();
            article.URL = $@"{article.Title}_{article.Id}";
            article.CreatedDate = DateTime.Now;
            article.UpdateDate = DateTime.Now;

            _context.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public void DeleteArticle(Guid? Id)
        {
            _context.Articles.FirstOrDefault(m => m.Id == Id);
        }

        public async Task<Article> DeleteArticleAsync(Guid? Id)
        {
            Article article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == Id);

            return article;
        }

        public async Task DeleteArticleConfirmedAsync(Guid? Id)
        {
            var article = await _context.Articles.FindAsync(Id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }

        public Article GetArticleById(Guid? Id)
        {
            var article = _context.Articles.FirstOrDefault(m => m.Id == Id);
            return article;
        }

        public async Task<Article> GetArticleByIdAsync(Guid? Id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(m => m.Id == Id);
            return article;
        }

        public List<Article> GetArticles()
        {
            var articles = _context.Articles.ToList();
            return articles;
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            var articles = await _context.Articles.ToListAsync();
            return articles;
        }

        public async Task<List<Article>> GetUserArticlesAsync(Guid Id)
        {
            var articles = await _context.Articles.Where(item => item.BrainStormUser.Id == Id)
                .ToListAsync();
            return articles;
        }

        public Article UpdateArticle(Guid? Id, Article article)
        {
            _context.Update(article);
            _context.SaveChanges();

            return article;
        }

        public async Task<Article> UpdateArticleAsync(Guid? Id, Article article)
        {
            article.UpdateDate = DateTime.Now;
            _context.Update(article);
            await _context.SaveChangesAsync();

            return article;
        }
    }
}

using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        public bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

        public Article CreateArticle(Article article)
        {
            _context.Add(article);
            _context.SaveChanges();
            return article;
        }

        public async Task<Article> CreateArticleAsync(Article article)
        {
            article.URL = $@"{article.Title}_{article.Id}";
            article.CreatedDate = DateTime.Now;
            article.UpdateDate = DateTime.Now;

            _context.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public void DeleteArticle(int? Id)
        {
            _context.Articles.FirstOrDefault(m => m.Id == Id);
        }

        public async Task<Article> DeleteArticleAsync(int? Id)
        {
            Article article = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == Id);

            return article;
        }

        public async Task DeleteArticleConfirmedAsync(int? Id)
        {
            var article = await _context.Articles.FindAsync(Id);
            var imagePath = article.Picture;

            if (imagePath != null && imagePath.Length > 0 && File.Exists($@"wwwroot/{imagePath}"))
            {
                await Task.Factory.StartNew(() => File.Delete($@"wwwroot/{imagePath}"));
            }

            _context.Articles.Remove(article);
            Task.WaitAll(_context.SaveChangesAsync());
        }

        public Article GetArticleById(int? Id)
        {
            var article = _context.Articles.FirstOrDefault(m => m.Id == Id);
            return article;
        }

        public async Task<Article> GetArticleByIdAsync(int? Id)
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
            var articles = await _context.Articles
                .Where(m => m.BrainStormUser.Id == Id)
                .ToListAsync();

            return articles;
        }

        public Article UpdateArticle(int? Id, Article article)
        {
            _context.Update(article);
            _context.SaveChanges();

            return article;
        }

        public async Task<Article> UpdateArticleAsync(int? Id, Article article)
        {
            article.UpdateDate = DateTime.Now;
            _context.Update(article);
            await _context.SaveChangesAsync();

            return article;
        }
    }
}

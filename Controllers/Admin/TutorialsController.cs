using BrainStorm.Areas.Identity.Data;
using BrainStorm.Areas.Identity.Services;
using BrainStorm.Helpers;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using BrainStorm.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BrainStorm.Controllers.Admin
{
    [Authorize]
    public class TutorialsController : Controller
    {
        private readonly BrainStormDbContext _context;
        IUnitService _unitService;


        public TutorialsController(BrainStormDbContext context, IUnitService unitService)
        {
            _context = context;
            _unitService = unitService;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var articles = await _unitService.Article.GetUserArticlesAsync(Guid.Parse(userId));

            var articlesViewModel = new List<ArticlesViewModel>();
            foreach (var article in articles)
            {
                var category = await _unitService.ArticleCategory.getCategoryByArticleIdAsync(article.Id);

                ArticlesViewModel ArticleCategory = new ArticlesViewModel()
                {
                    Id = article.Id,
                    Title = article.Title,
                    ArticleCategory = category,
                    PostCategory = article.PostCategory,
                    Row = article.Row,
                    CreatedDate = article.CreatedDate,
                    UpdateDate = article.UpdateDate
                };

                articlesViewModel.Add(ArticleCategory);
            }
            return View(articlesViewModel);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _unitService.Article.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ArticleViewModel article = new ArticleViewModel()
            {
                Category = _unitService.Category.GetAll()
            };
            return View(article);
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Row,Content")] Article article, int CategoryId, IFormFile files /*IEnumerable<IFormFile>* [FromBody] List<Photo> photos)*/)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            List<ArticleCategory> articleCategory = new List<ArticleCategory>() { };
            var category = await _unitService.Category.GetByIdAsync(CategoryId);
            ArticleCategory cat = new ArticleCategory { Category = category };
            articleCategory.Add(cat);

            article.ArticleCategory = articleCategory;
            article.PostCategory = PostCategory.Tutorial;
            article.BrainStormUser = await _unitService.User.GetUsersByIdAsync(userId);
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
                _unitService.Article.Create(article);
                if (files != null && files.Length > 0)
                {
                    ImageHelper imageHelper = new ImageHelper(_context);
                    imageHelper.UpdateImage(article.Id, files, "article", article);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article.Picture == null)
            {
                article.Picture = "images/article/default_article.jpg";
                await _context.SaveChangesAsync();
            }
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Row,Category,Content")] Article postArticle, IFormFile files)
        {
            var article = await _unitService.Article.GetByIdAsync(postArticle.Id);

            if (id != postArticle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    article.Title = postArticle.Title;
                    article.URL = $@"{postArticle.Title}_{postArticle.Id}";
                    article.Row = postArticle.Row;
                    article.ArticleCategory = postArticle.ArticleCategory;
                    article.Content = postArticle.Content;
                    _unitService.Article.Update(article);
                    if (files != null && files.Length > 0)
                    {
                        ImageHelper imageHelper = new ImageHelper(_context);
                        imageHelper.UpdateImage(id, files, "article", article);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(postArticle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _unitService.Article.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Article article)
        {
            _unitService.Article.DeleteConfirmed(article);
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _unitService.Article.Exists(id);
        }
    }
}

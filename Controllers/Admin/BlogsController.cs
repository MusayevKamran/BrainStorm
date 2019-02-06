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
    public class BlogsController : Controller
    {
        private readonly BrainStormDbContext _context;
        IUnitService _unitService;

        public BlogsController(BrainStormDbContext context, IUnitService unitService)
        {
            _context = context;
            _unitService = unitService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var articles = await _unitService.Article.GetUserBlogsAsync(Guid.Parse(userId));

            var articlesViewModel = new List<ArticlesViewModel>();
            foreach (var article in articles)
            {
                var categories = await _unitService.ArticleCategory.getCategoryByArticleIdAsync(article.Id);
                var categoryList = new List<Category>();
                foreach (var item in categories)
                {
                    var category = await _unitService.Category.GetByIdAsync(item.CategoryId);
                    categoryList.Add(category);
                }

                ArticlesViewModel ArticleCategory = new ArticlesViewModel()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Category = categoryList,
                    PostCategory = article.PostCategory,
                    Row = article.Row,
                    CreatedDate = article.CreatedDate,
                    UpdateDate = article.UpdateDate
                };

                articlesViewModel.Add(ArticleCategory);
            }
            return View(articlesViewModel);
        }


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


        public IActionResult Create()
        {
            ArticleViewModel article = new ArticleViewModel()
            {
                Category = _unitService.Category.GetAll()
            };
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Row,Content")] Article article, int CategoryId, IFormFile files)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            List<ArticleCategory> articleCategory = new List<ArticleCategory>() { };
            var category = await _unitService.Category.GetByIdAsync(CategoryId);
            ArticleCategory cat = new ArticleCategory { Category = category };
            articleCategory.Add(cat);

            article.ArticleCategory = articleCategory;
            article.PostCategory = PostCategory.Blog;
            article.CreatedDate = DateTime.Now;
            article.UpdateDate = DateTime.Now;
            article.BrainStormUser = await _unitService.User.GetUsersByIdAsync(userId);
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
                _unitService.Article.Create(article);
                _unitService.SaveChanges();
                if (files != null && files.Length > 0)
                {
                    ImageHelper imageHelper = new ImageHelper(_context);
                    imageHelper.UpdateImage(article.Id, files, "article", article);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ArticleViewModel article = new ArticleViewModel()
            {
                Article = await _unitService.Article.GetByIdAsync(id),
                Category = _unitService.Category.GetAll()
            };

            var articleCategory = await _unitService.ArticleCategory.getCategoryByArticleIdAsync(id);
            var catId = articleCategory.First().CategoryId;
            var catName = await _unitService.Category.GetByIdAsync(catId);

            ViewBag.category = catName.Name;

            if (article.Article.Image == null)
            {
                article.Article.Image = "images/article/default_article.jpg";
                await _context.SaveChangesAsync();
            }
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleViewModel postArticle, int CategoryId, IFormFile files)
        {
            var article = await _unitService.Article.GetByIdAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    article.Title = postArticle.Article.Title;
                    article.URL = $@"{postArticle.Article.Title}_{postArticle.Article.Id}";
                    article.Row = postArticle.Article.Row;

                    if (CategoryId != 0)
                    {
                        var articleCategory = _unitService.ArticleCategory.updateArticleCategoryAsync(id, CategoryId);
                    }

                    article.Content = postArticle.Article.Content;
                    article.UpdateDate = DateTime.Now;
                    _unitService.Article.Update(article);
                    _unitService.SaveChanges();

                    if (files != null && files.Length > 0)
                    {
                        ImageHelper imageHelper = new ImageHelper(_context);
                        imageHelper.UpdateImage(id, files, "article", article);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(postArticle.Article.Id))
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

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Article article)
        {
            _unitService.Article.DeleteConfirmed(article);
            _unitService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _unitService.Article.Exists(id);
        }
    }
}

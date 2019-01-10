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
        IArticle _articleService;
        ICategory _categoryService;


        public TutorialsController(BrainStormDbContext context, IArticle articleService, ICategory categoryService)
        {
            _context = context;
            _articleService = articleService;
            _categoryService = categoryService;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var articles = await _articleService.GetUserArticlesAsync(Guid.Parse(userId));

            var articlesViewModel = new List<ArticlesViewModel>();
            foreach (var item in articles)
            {
                var category = await _categoryService.GetCategoryByIdAsyncExtra(item.Id);

                ArticlesViewModel ArticleCategory = new ArticlesViewModel()
                {
                    Id = articles.First().Id,
                    Title = articles.First().Title,
                    ArticleCategory = category,
                    //articles.First().ArticleCategory,
                    PostCategory = articles.First().PostCategory,
                    Row = articles.First().Row,
                    CreatedDate = articles.First().CreatedDate,
                    UpdateDate = articles.First().UpdateDate       
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

            var article = await _articleService.GetByIdAsync(id);

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
                ArticleCategory = _categoryService.GetAll()
            };
            return View(article);
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Row,Content,BrainStormUser")] Article article, List<int> CategoryId, IFormFile files /*IEnumerable<IFormFile>* [FromBody] List<Photo> photos)*/)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserService userService = new UserService(_context);


            article.ArticleCategory = new List<ArticleCategory>() {
                new ArticleCategory { CategoryId = CategoryId.First() },
                new ArticleCategory { CategoryId = CategoryId.Last() }
            };

            article.PostCategory = PostCategory.Tutorial;
            //article.Category = category;
            article.BrainStormUser = await userService.GetUsersByIdAsync(userId);
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
                await _articleService.CreateAsync(article);
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
        public async Task<IActionResult> Edit(Guid? id)
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
            var article = await _articleService.GetByIdAsync(postArticle.Id);

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
                    await _articleService.UpdateAsync(id, article);
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

            var article = await _articleService.DeleteAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _articleService.Exists(id);
        }
    }
}

using BrainStorm.Areas.Identity.Data;
using BrainStorm.Areas.Identity.Services;
using BrainStorm.Helpers;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            var articles = await _unitService.Article.GetAllAsync();
            return View(articles);
        }

        // GET: Blogs/Details/5
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

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,URL,Row,Category,Content,Picture,PostCategory")] Article article, IFormFile files)
        {
            article.PostCategory = PostCategory.Blog;
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
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

                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Row,ArticleCategory,Content,PostCategory")] Article postArticle, IFormFile files)
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
                    article.PostCategory = postArticle.PostCategory;
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

        // GET: Blogs/Delete/5
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
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _unitService.Article.Exists(id);
        }
    }
}

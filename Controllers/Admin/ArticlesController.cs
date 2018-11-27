using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Areas.Identity.Services;

namespace BrainStorm.Controllers.Admin
{
    public class ArticlesController : Controller
    {
        private readonly BrainStormDbContext _context;
        ArticleService _articleService;

        public ArticlesController(BrainStormDbContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            _articleService = new ArticleService(_context);
            var articles = await _articleService.GetArticlesAsync();
            return View(articles);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            _articleService = new ArticleService(_context);
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.GetArticleByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,URL,Row,Category,Content,Picture,Like,PostCategory")] Article article)
        {
            _articleService = new ArticleService(_context);
            article.PostCategory = PostCategory.Tutorial;
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
                await _articleService.CreateArticleAsync(article);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Row,Category,Content,CreatedDate,Picture,PostCategory")] Article article)
        {
            _articleService = new ArticleService(_context);

            article.URL = $@"{article.Title}_{article.Id}";
            article.PostCategory = PostCategory.Tutorial;

            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _articleService.UpdateArticleAsync(id, article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
        public async Task<IActionResult> Delete(Guid? id)
        {
            _articleService = new ArticleService(_context);

            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.DeleteArticleAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _articleService = new ArticleService(_context);
            await _articleService.DeleteArticleConfirmedAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(Guid id)
        {
            _articleService = new ArticleService(_context);
            return _articleService.ArticleExists(id);
        }
    }
}

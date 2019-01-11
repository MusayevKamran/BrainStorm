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
using BrainStorm.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Create([Bind("Id,Title,URL,Row,Category,Content,Picture,PostCategory")] Article article)
        {
            article.PostCategory = PostCategory.Blog;
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
                await _unitService.Article.CreateAsync(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Blogs/Edit/5
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
                    await _unitService.Article.UpdateAsync(id, article);
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

            var article = await _unitService.Article.DeleteAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitService.Article.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _unitService.Article.Exists(id);
        }
    }
}

﻿using System;
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
using System.Security.Claims;
using BrainStorm.Areas.Identity.Service;
using BrainStorm.Models.Interface;

namespace BrainStorm.Controllers.Admin
{
    public class TutorialsController : Controller
    {
        private readonly BrainStormDbContext _context;
        IArticle _articleService; //IArticle interfeysi duzelt


        public TutorialsController(BrainStormDbContext context, IArticle articleService)
        {
            _context = context;
            _articleService= articleService;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var articles = await _articleService.GetUserArticlesAsync(Guid.Parse(userId));
            return View(articles);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
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
        public async Task<IActionResult> Create([Bind("Id,Title,Row,Category,Content,BrainStormUser")] Article article, IFormFile files /*IEnumerable<IFormFile>* [FromBody] List<Photo> photos)*/)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserService userService = new UserService(_context);

            article.PostCategory = PostCategory.Tutorial;
            article.BrainStormUser = await userService.GetUsersByIdAsync(userId);
            article.Row = _context.Articles.Any() == false ? 1 : _context.Articles.Max(item => item.Row + 1);

            if (ModelState.IsValid)
            {
                await _articleService.CreateArticleAsync(article);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Row,Category,Content")] Article postArticle, IFormFile files)
        {
            var article = await _articleService.GetArticleByIdAsync(postArticle.Id);

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
                    article.Category = postArticle.Category;
                    article.Content = postArticle.Content;
                    await _articleService.UpdateArticleAsync(id, article);
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
        public async Task<IActionResult> Delete(Guid? id)
        {
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
            await _articleService.DeleteArticleConfirmedAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(Guid id)
        {
            return _articleService.ArticleExists(id);
        }
    }
}

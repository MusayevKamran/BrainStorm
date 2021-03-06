﻿using BrainStorm.Areas.Identity.Data;
using BrainStorm.Areas.Identity.Services;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using BrainStorm.ViewModel.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace BrainStorm.Controllers.API
{
    //[Authorize(Roles = UserStatus.ADMIN)]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly BrainStormDbContext _context;
        private readonly IUnitService _unitService;

        public ArticlesController(BrainStormDbContext context, IUnitService unitService)
        {
            _context = context;
            _unitService = unitService;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        [HttpGet("tutorials")]
        public async Task<IEnumerable<Article>> GetTutorials()
        {
            return await _unitService.Article.GetTutorialsAsync();
        }

        [HttpGet("blogs")]
        public async Task<IEnumerable<Article>> GetBlogs()
        {
            return await _unitService.Article.GetBlogsAsync();
        }

        [HttpGet("tutorials/category/{id}")]
        public async Task<List<TutorialsNameViewModel>> GetTutorialsName(int id)
        {
            var articles = await _context.Articles
                .Where(category =>
                category.ArticleCategory.FirstOrDefault().CategoryId == id &&
                category.PostCategory == PostCategory.Tutorial
                )
              .Select(a => new TutorialsNameViewModel()
              {
                  Id = a.Id,
                  Title = a.Title,
                  Row = a.Row
              })
                .ToListAsync();

            return articles;
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] int id)
        {
            var article = await _context.Articles.FindAsync(id);

            List<ArticleCategory> articleCategory = new List<ArticleCategory>() { };

            var category = await _unitService.Category.GetByIdAsync(id);

            var arCat = await _unitService.ArticleCategory.getCategoryByArticleIdAsync(id);

            // string a = "";
            //foreach (var item in arCat)
            //{
            //    articleCategory.Add(item);
            //}

            //article.ArticleCategory = articleCategory;

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle([FromRoute] int id, [FromBody] Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Articles
        [HttpPost]
        public async Task<IActionResult> PostArticle([FromBody] Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return Ok(article);
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
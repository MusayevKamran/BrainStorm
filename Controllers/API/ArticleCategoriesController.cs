using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;

namespace BrainStorm.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoriesController : ControllerBase
    {
        private readonly BrainStormDbContext _context;

        public ArticleCategoriesController(BrainStormDbContext context)
        {
            _context = context;
        }

        // GET: api/ArticleCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleCategory>>> GetArticleCategories()
        {
            return await _context.ArticleCategories.ToListAsync();
        }

        // GET: api/ArticleCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleCategory>> GetArticleCategory(int id)
        {
            var articleCategory = await _context.ArticleCategories.FindAsync(id);

            if (articleCategory == null)
            {
                return NotFound();
            }

            return articleCategory;
        }

        // PUT: api/ArticleCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleCategory(int id, ArticleCategory articleCategory)
        {
            if (id != articleCategory.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(articleCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleCategoryExists(id))
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

        // POST: api/ArticleCategories
        [HttpPost]
        public async Task<ActionResult<ArticleCategory>> PostArticleCategory(ArticleCategory articleCategory)
        {
            _context.ArticleCategories.Add(articleCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArticleCategoryExists(articleCategory.ArticleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArticleCategory", new { id = articleCategory.ArticleId }, articleCategory);
        }

        // DELETE: api/ArticleCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArticleCategory>> DeleteArticleCategory(int id)
        {
            var articleCategory = await _context.ArticleCategories.FindAsync(id);
            if (articleCategory == null)
            {
                return NotFound();
            }

            _context.ArticleCategories.Remove(articleCategory);
            await _context.SaveChangesAsync();

            return articleCategory;
        }

        private bool ArticleCategoryExists(int id)
        {
            return _context.ArticleCategories.Any(e => e.ArticleId == id);
        }
    }
}

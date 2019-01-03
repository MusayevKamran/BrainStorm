using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using Microsoft.AspNetCore.Authorization;
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

        public ArticlesController(BrainStormDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles;
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] Guid id)
        {
            var article = await _context.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle([FromRoute] Guid id, [FromBody] Article article)
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
        public async Task<IActionResult> DeleteArticle([FromRoute] Guid id)
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

        private bool ArticleExists(Guid id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
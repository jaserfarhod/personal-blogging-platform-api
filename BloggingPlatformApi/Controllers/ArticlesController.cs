using BloggingPlatformApi.Models;
using BloggingPlatformApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticlesService _articlesService;

        public ArticlesController(ArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [HttpGet]
        public async Task<List<Article>> Get()
        {
            return await _articlesService.GetArticles();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Article>> Get(string id)
        {
            var article = await _articlesService.GetArticle(id);
            if (article is null)
            {
                return NotFound();
            }
            return article;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Article newArticle)
        {
            await _articlesService.CreateArticle(newArticle);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id}, newBook);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Article updatedArticle)
        {
            var article = await _articlesService.GetArticle(id);

            if (article is null)
            {
                return NotFound();
            }

            updatedArticle.Id = article.Id;
            await _articlesService.UpdateArticle(id, updatedArticle)

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var article = await _articlesService.GetArticle(id);

            if (article is null)
            {
                return NotFound();
            }

            await _articlesService.RemoveArticle(id);

            return NoContent();
        }
    }
}

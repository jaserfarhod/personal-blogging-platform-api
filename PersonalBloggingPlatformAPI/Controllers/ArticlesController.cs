using Microsoft.AspNetCore.Mvc;

namespace PersonalBloggingPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        // GET: api/Articles
        [HttpGet]
        public IActionResult GetAllArticles()
        {
            // TODO: Retrieve all articles
            return Ok();
        }

        // GET: api/Articles/{id}
        [HttpGet("{id}")]
        public IActionResult GetArticleById(int id)
        {
            // TODO: Retrieve article by id
            return Ok();
        }

        // POST: api/Articles
        [HttpPost]
        public IActionResult CreateArticle([FromBody] object articleDto)
        {
            // TODO: Create a new article
            return CreatedAtAction(nameof(GetArticleById), new { id = 0 }, articleDto);
        }

        // PUT: api/Articles/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, [FromBody] object articleDto)
        {
            // TODO: Update article by id
            return NoContent();
        }

        // DELETE: api/Articles/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            // TODO: Delete article by id
            return NoContent();
        }
    }
}

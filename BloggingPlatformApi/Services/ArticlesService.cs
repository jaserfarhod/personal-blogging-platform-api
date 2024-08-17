using BloggingPlatformApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BloggingPlatformApi.Services
{
    public class ArticlesService
    {
        private readonly IMongoCollection<Article> _articlesCollection;

        public ArticlesService(
            IOptions<BloggingPlatformDatabaseSettings> bloggingPlatformDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bloggingPlatformDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bloggingPlatformDatabaseSettings.Value.DatabaseName);

            _articlesCollection = mongoDatabase.GetCollection<Article>(
                bloggingPlatformDatabaseSettings.Value.ArticlesCollectionName);
        }

        public async Task<List<Article>> GetArticles(string? publishDate, List<string>? tags)
        {
            var filterBuilder = Builders<Article>.Filter;
            var filter = filterBuilder.Empty; // Start with an empty filter

            if (!string.IsNullOrEmpty(publishDate))
            {
                filter &= filterBuilder.Eq(article => article.PublishDate, publishDate);
            }

            if (tags != null && tags.Count > 0)
            {
                filter &= filterBuilder.All(article => article.Tags, tags);
            }

            return await _articlesCollection.Find(filter).ToListAsync();
        }


        public async Task<Article?> GetArticle(string id) =>
            await _articlesCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateArticle(Article newArticle) =>
            await _articlesCollection.InsertOneAsync(newArticle);

        public async Task UpdateArticle(string id, Article updatedArticle) =>
            await _articlesCollection.ReplaceOneAsync(a => a.Id == id, updatedArticle);

        public async Task RemoveArticle(string id) =>
            await _articlesCollection.DeleteOneAsync(a => a.Id == id);
    }
}

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

        public async Task<List<Article>> GetAsync() =>
            await _articlesCollection.Find(_ => true).ToListAsync();

        public async Task<Article?> GetAsync(string id) =>
            await _articlesCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Article newArticle) =>
            await _articlesCollection.InsertOneAsync(newArticle);

        public async Task UpdateAsync(string id, Article updatedArticle) =>
            await _articlesCollection.ReplaceOneAsync(a => a.Id == id, updatedArticle);

        public async Task RemoveAsync(string id) =>
            await _articlesCollection.DeleteOneAsync(a => a.Id == id);
    }
}

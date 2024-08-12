using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BloggingPlatformApi.Models
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public List<string> Tags { get; set; } = null!;
        public string PublishDate { get; set; } = null!;
        public string Author { get; set; } = null!;

    }
}

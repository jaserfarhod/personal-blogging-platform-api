namespace BloggingPlatformApi.Models
{
    public class BloggingPlatformDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ArticlesCollectionName { get; set; } = null!;
    }
}

namespace TaskManager.Api.Configuration
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string TasksCollectionName { get; set; } = string.Empty;
    }
}

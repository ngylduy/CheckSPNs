namespace CheckSPNs.Data.MongoDb.Context
{
    public class MongoDatabaseOptions
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}

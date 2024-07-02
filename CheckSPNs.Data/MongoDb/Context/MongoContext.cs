using CheckSPNs.Data.MongoDb.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CheckSPNs.Data.MongoDb.Context
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(IOptions<MongoDatabaseOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            Database = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoDatabase Database { get; }
    }
}

using MongoDB.Driver;

namespace CheckSPNs.Data.MongoDb.Abstract
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}

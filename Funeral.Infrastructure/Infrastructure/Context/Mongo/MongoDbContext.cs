using MongoDB.Driver;
using System.Configuration;

namespace Infrastructure.Context.Mongo
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private IMongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoDbContext()
        {
            _mongoClient = new MongoClient(ConfigurationManager.ConnectionStrings["FuneralMongo"].ConnectionString);

            _db = _mongoClient.GetDatabase("funeralOrder");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return _db.GetCollection<T>(name);
        }

        public IMongoCollection<MongoFuneral> GetCollectionFuneral<MongoFuneral>()
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<MongoItems> GetCollectionFuneralItems<MongoItems>()
        {
            throw new NotImplementedException();
        }
    }
}

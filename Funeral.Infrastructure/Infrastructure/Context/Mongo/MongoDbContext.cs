using Infrastructure.Mongo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Configuration;

namespace Infrastructure.Context.Mongo
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["FuneralMongo"].ConnectionString);
            if (client != null)
                _database = client.GetDatabase("funeralOrder");
        }

        public IMongoCollection<MongoFuneral> MyEntities
        {
            get
            {
                return _database.GetCollection<MongoFuneral>("MongoFuneral");
            }
        }
    }

    public class Settings
    {
        public string MongoDBConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

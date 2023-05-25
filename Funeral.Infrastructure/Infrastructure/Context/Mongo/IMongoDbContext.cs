using MongoDB.Driver;

namespace Infrastructure.Context.Mongo
{
    public interface IMongoDbContext
    {
        IMongoCollection<MongoFuneral> GetCollectionFuneral<MongoFuneral>();
        IMongoCollection<MongoItems> GetCollectionFuneralItems<MongoItems>();
    }
}

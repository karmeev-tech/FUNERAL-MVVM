using Infrastructure.Model.Services;
using Infrastructure.Model.Storage;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace Infrastructure.Mongo
{
    public class MongoServices
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FuneralMongo"].ConnectionString;

        public static void ConnectAndAddFile(ServiceEntity stateEntity)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<ServiceEntity>("services");


            collection.InsertOne(stateEntity);
        }
        public static void ConnectAndDeleteFile(ServiceEntity stateEntity)
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<ServiceEntity>("services");
            var filter = Builders<ServiceEntity>.Filter.Eq("_id", stateEntity.Id);

            collection.DeleteOne(filter);
        }
        public static int GetUniqueId()
        {
            var id = 0;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<ServiceEntity>("services");
            try
            {
                var sortedDocument = collection.Find(new BsonDocument()).Sort(Builders<ServiceEntity>.Sort.Ascending("_id")).ToList().Last();
                id = sortedDocument.Id + 1;
                return id;
            }
            catch
            {
                return 0;
            }
        }

        public static void ConnectAndDeleteAllFiles()
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<ServiceEntity>("services");
            collection.DeleteMany(new BsonDocument());
        }

        public static List<ServiceEntity> GetItems()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<ServiceEntity>("services");

            var documents = collection.Find(new BsonDocument()).ToList();
            List<ServiceEntity> result = new();
            foreach (var item in documents)
            {
                result.Add(item);
            }
            return result;
        }
    }
}

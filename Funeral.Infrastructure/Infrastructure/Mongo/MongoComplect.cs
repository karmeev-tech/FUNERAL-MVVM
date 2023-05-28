using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Services;
using Infrastructure.Model.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace Infrastructure.Mongo
{
    public class MongoComplect
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FuneralMongo"].ConnectionString;

        public static void ConnectAndAddFile(StorageItemEntity stateEntity)
        {
            // Create a MongoClient object to connect to the MongoDB server
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StorageItemEntity>("complect");


            collection.InsertOne(stateEntity);
        }

        public static void ConnectAndDeleteFile(StorageItemEntity stateEntity)
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StorageItemEntity>("complect");
            var filter = Builders<StorageItemEntity>.Filter.Eq("_id", stateEntity.Id);

            collection.DeleteOne(filter);
        }

        public static bool CheckDoc(int number)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("funeralOrder");
                var collection = database.GetCollection<StorageItemEntity>("complect");
                var sortedDocument = collection.Find(new BsonDocument())
                    .Sort(Builders<StorageItemEntity>
                    .Sort.Ascending("_id"))
                    .ToList()
                    .Where(x => x.Id == number);

                if (!sortedDocument.Any())
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ConnectAndDeleteAllFiles()
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StorageItemEntity>("complect");
            collection.DeleteMany(new BsonDocument());
        }

        public static List<StorageItemEntity> GetItems()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<StorageItemEntity>("complect");

            var documents = collection.Find(new BsonDocument()).ToList();
            List<StorageItemEntity> result = new();
            foreach (var item in documents)
            {
                result.Add(item);
            }
            return result;
        }

        public static int GetUniqueId()
        {
            var id = 0;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<StorageItemEntity>("complect");
            try
            {
                var sortedDocument = collection.Find(new BsonDocument()).Sort(Builders<StorageItemEntity>.Sort.Ascending("_id")).ToList().Last();
                id = sortedDocument.Id + 1;
                return id;
            }
            catch
            {
                return 0;
            }
        }
    }
}

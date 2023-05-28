using Domain.Order;
using Infrastructure.Model.Storage;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Configuration;

namespace Infrastructure.Mongo
{
    public class MongoItems
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FuneralMongo"].ConnectionString;
        public static void Connect()
        {
            // Create a MongoClient object to connect to the MongoDB server
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StorageItemEntity>("items");
        }
        public static void ConnectAndAddFile(StorageItemEntity stateEntity)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<StorageItemEntity>("items");


            collection.InsertOne(stateEntity);
        }
        public static void ConnectAndDeleteFile(StorageItemEntity stateEntity)
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StorageItemEntity>("orders");
            var filter = Builders<StorageItemEntity>.Filter.Eq("_id", stateEntity.Id);

            collection.DeleteOne(filter);
        }
        public static int GetUniqueId()
        {
            var id = 0;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<StorageItemEntity>("items");
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
        public static void GetJsonFilesFolder(string path)
        {
            // Create a MongoClient object to connect to the MongoDB server
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StorageItemEntity>("items");
            var documents = collection.Find(new BsonDocument()).ToList();

            foreach (var document in documents)
            {
                JsonWriterSettings settings = new JsonWriterSettings
                {
                    Indent = true
                };
                var json = document.ToJson(settings);
                File.WriteAllText(path + "\\json" + new Random().Next().ToString() + ".json", json);
            }
        }
        public static void ConnectAndDeleteAllFiles()
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StorageItemEntity>("items");
            collection.DeleteMany(new BsonDocument());
        }

        public static List<StorageItemEntity> GetItems()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<StorageItemEntity>("items");

            var documents = collection.Find(new BsonDocument()).ToList();
            List<StorageItemEntity> result = new();
            foreach (var item in documents)
            {
                result.Add(item);
            }
            return result;
        }
    }
}

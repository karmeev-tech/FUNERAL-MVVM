using Domain.Complect;
using Domain.Order.Config;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Storage;
using MongoDB.Bson;
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
            var collection = database.GetCollection<ItemComplectEntity>("items");
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
            var collection = database.GetCollection<ItemComplectEntity>("orders");
            var filter = Builders<ItemComplectEntity>.Filter.Eq("_id", stateEntity.Id);

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
                var json = documents.ToJson();
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
    }
}

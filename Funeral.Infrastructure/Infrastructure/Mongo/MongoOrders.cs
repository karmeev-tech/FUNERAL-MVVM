using Domain.Order;
using Infrastructure.Model.Services;
using Infrastructure.Model.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mongo
{
    public class MongoOrders
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FuneralMongo"].ConnectionString;

        public static void ConnectAndAddFile(OrderEntity stateEntity)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<OrderEntity>("tempOrder");


            collection.InsertOne(stateEntity);
        }
        public static void ConnectAndDeleteFile(OrderEntity stateEntity)
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<OrderEntity>("tempOrder");
            var filter = Builders<OrderEntity>.Filter.Eq("_id", stateEntity.Id);

            collection.DeleteOne(filter);
        }
        public static int GetUniqueId()
        {
            var id = 0;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<OrderEntity>("tempOrder");
            try
            {
                var sortedDocument = collection.Find(new BsonDocument()).Sort(Builders<OrderEntity>.Sort.Ascending("_id")).ToList().Last();
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
            var collection = database.GetCollection<OrderEntity>("tempOrder");
            collection.DeleteMany(new BsonDocument());
        }

        public static List<OrderEntity> GetItems()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("funeralOrder");
            var collection = database.GetCollection<OrderEntity>("tempOrder");

            var documents = collection.Find(new BsonDocument()).ToList();
            List<OrderEntity> result = new();
            foreach (var item in documents)
            {
                result.Add(item);
            }
            return result;
        }
    }
}

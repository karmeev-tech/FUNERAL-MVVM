using Infrastructure.Model.ComplexMongo;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Configuration;

namespace Infrastructure.Mongo
{
    public class MongoFuneral
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["FuneralMongo"].ConnectionString;
        public static void Connect()
        {
            // Create a MongoClient object to connect to the MongoDB server
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");
        }

        public static void ConnectAndAddFile(StateEntity stateEntity)
        {
            // Create a MongoClient object to connect to the MongoDB server
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StateEntity>("orders");


            collection.InsertOne(stateEntity);
        }
        public static void ConnectAndDeleteFile(StateEntity stateEntity)
        {
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StateEntity>("orders");
            var filter = Builders<StateEntity>.Filter.Eq("_id", stateEntity.Id);

            collection.DeleteOne(filter);
        }
        public static int GetUniqueId()
        {
            var id = 0;
            // Create a MongoClient object to connect to the MongoDB server
            var client = new MongoClient(connectionString);

            // Use the MongoClient object to get a reference to a database
            var database = client.GetDatabase("funeralOrder");

            // Use the database reference to create a collection
            var collection = database.GetCollection<StateEntity>("orders");
            try
            {
                var sortedDocument = collection.Find(new BsonDocument()).Sort(Builders<StateEntity>.Sort.Ascending("_id")).ToList().Last();
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
            var collection = database.GetCollection<StateEntity>("orders");
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
            var collection = database.GetCollection<StateEntity>("orders");
            collection.DeleteMany(new BsonDocument());
        }
        public static bool CheckDoc(int number)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("funeralOrder");
                var collection = database.GetCollection<StateEntity>("orders");
                var sortedDocument = collection.Find(new BsonDocument())
                    .Sort(Builders<StateEntity>
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
    }
}

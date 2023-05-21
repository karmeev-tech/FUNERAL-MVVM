using ClassLibrary;
using Infrastructure.Model.Storage;
using Infrastructure.Model.Worker;
using MongoDB.Driver;
using Shop.EF;
using System.Text.Json;
using System.Windows;
using Worker.EF;

namespace ConfigBoss
{
    public class Head
    {
        public static void MakeGeneralConfigFile()
        {
            string filename = "\\conf.json";

            ConfigModel model = new ConfigModel();


            model.Shops = ShopConnector.GetShops();
            model.ShopsItems = ShopConnector.GetAllStorageItems();
            model.Workers = WorkerConnector.GetWorkers();
            model.Salary = WorkerConnector.GetAllSalary();

            Head.AddDocument(model,filename);
        }

        private static void AddDocument(ConfigModel workers, string fileName)
        {
            using FileStream createStream = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fileName);
            JsonSerializer.SerializeAsync(createStream, workers, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            createStream.DisposeAsync();
        }

        public static void Upload()
        {
            PickManager pickManager = new PickManager();
            var jsonPath = pickManager.OpenManagerFileNameJson();
            //var jsonPath = "C:\\Users\\kirill.karmeev\\Desktop\\conf.json";
            if (jsonPath == "")
            {
                return;
            }

            try
            {
                string json = "";
                using (StreamReader r = new StreamReader(jsonPath))
                {
                    json = r.ReadToEnd();
                }
                var result = JsonSerializer.Deserialize<ConfigModel>(json);
                //шмотки
                ShopConnector.UpdateAllDB(result.ShopsItems);

                //магазины
                List<StorageEntity> storageEntities = new List<StorageEntity>();

                foreach (var shop in result.Shops)
                {
                    var storage = ShopConnector.GetShop(shop);
                    storageEntities.Add(storage);
                }
                ShopConnector.UpdateShopsAllDB(storageEntities);

                //работнички
                WorkerConnector.UpdateAllWorkers(result.Workers);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Storage;
using Newtonsoft.Json;
using ORDCreator;
using System.Configuration;

namespace BossInstruments
{
    public class FinalOrderManager
    {
        public static void GetDord(string bossFolder, string dordFile)
        {
            var programWorkspace = ConfigurationManager.AppSettings["ProgramWorkspaceDord"];

            if (Directory.Exists(programWorkspace))
            {
                Directory.Delete(programWorkspace, true);
            }
            Directory.CreateDirectory(programWorkspace);

            Zipper.UnZip(dordFile, programWorkspace);
        }

        public static List<StorageItemEntity> GetJsonItems()
        {
            var jsonPath = ConfigurationManager.AppSettings["ProgramWorkspaceDord"] + @"\itemsjson";
            List<StorageItemEntity> items = new();
            foreach (var item in Directory.GetFiles(jsonPath))
            {
                StorageItemEntity shopitem = JsonConvert.DeserializeObject<StorageItemEntity>(File.ReadAllText(item));
                items.Add(shopitem);
            }
            return items;
        }

        public static List<StateEntity> GetJsonOrders()
        {
            var jsonPath = ConfigurationManager.AppSettings["ProgramWorkspaceDord"] + @"\orderjson";
            List<StateEntity> items = new();
            foreach (var item in Directory.GetFiles(jsonPath))
            {
                StateEntity shopitem = JsonConvert.DeserializeObject<StateEntity>(File.ReadAllText(item));
                items.Add(shopitem);
            }
            return items;
        }
    }
}

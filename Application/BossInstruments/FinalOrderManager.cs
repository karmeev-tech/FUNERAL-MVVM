using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Storage;
using Newtonsoft.Json;
using ORDCreator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossInstruments
{
    public class FinalOrderManager
    {
        public static void GetDord(string bossFolder, string dordFile)
        {
            var programWorkspace = ConfigurationManager.AppSettings["ProgramWorkspaceDord"];

            if(Directory.Exists(programWorkspace))
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
                List<StorageItemEntity> shopitem = JsonConvert.DeserializeObject<List<StorageItemEntity>>(File.ReadAllText(item));
                items.AddRange(shopitem);
            }
            return items;
        }

        public static List<StateEntity> GetJsonOrders()
        {
            var jsonPath = ConfigurationManager.AppSettings["ProgramWorkspaceDord"] + @"\orderjson";
            List<StateEntity> items = new();
            foreach (var item in Directory.GetFiles(jsonPath))
            {
                List<StateEntity> shopitem = JsonConvert.DeserializeObject<List<StateEntity>>(File.ReadAllText(item));
                items.AddRange(shopitem);
            }
            return items;
        }
    }
}

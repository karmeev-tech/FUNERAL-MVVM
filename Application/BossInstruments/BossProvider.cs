using Domain.Dord;
using Domain.GeneralOrder;
using Domain.Shop;
using Infrastructure.Model.Storage;
using LegacyInfrastructure.Salary;
using LegacyInfrastructure.Storage;
using ORDCreator;
using System.Collections.Generic;

namespace BossInstruments
{
    public class BossProvider
    {
        private static IShopRepos _shopRepos = new ShopRepos();
        private static SalaryManager _salaryManager = new();

        public static (IordEntity iord, DordMeta meta, List<OrdEntity> ord) 
            GetFiles(string dordFile, string bossFolder)
        {
            Zipper zipper = new();
            zipper.UnZip(dordFile, bossFolder);

            IordEntity iord = IordFormalizer.GetJson(Directory.GetFiles(bossFolder + @"\iord"));

            DordMeta meta = DordMetaFormalizer.GetJson(bossFolder + @"\json\request.json");

            var gendocsDir = bossFolder + @"\gendocs";
            var scandocsDir = bossFolder + @"\scandocs";

            List<OrdEntity> ord = XordFormalizer.GetJson(
                Directory.GetFiles(bossFolder + @"\xord"),
                bossFolder,
                gendocsDir, scandocsDir, "manager");

            Directory.Delete(bossFolder + @"\iord", true);
            Directory.Delete(bossFolder + @"\json", true);
            Directory.Delete(bossFolder + @"\xord", true);

            return (iord: iord, meta: meta, ord: ord);
        }

        public static void SendToDB(
            List<DordEntity> worker, 
            List<StorageItemEntity> items, 
            List<OrderDord> orders)
        {
            DBSender sender = new(_shopRepos,_salaryManager);
            //sender.ChangeStorage(items);

            sender.ChangeSalary(worker[0].ManagerName, Convert.ToInt32(worker[0].Salary));
        }

        public static void SendInvent(List<StorageItemEntity> storageItemEntities)
        {
            new InventSender().Send(storageItemEntities);
        }

        public static List<StorageItemEntity> GetInvent(string pathToJson)
        {
            return new InventSender().Get(pathToJson);
        }
    }
}

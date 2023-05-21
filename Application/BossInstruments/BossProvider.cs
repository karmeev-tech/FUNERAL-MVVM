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

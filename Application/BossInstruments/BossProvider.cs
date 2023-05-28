using Domain.Dord;
using Infrastructure.Model.Storage;
namespace BossInstruments
{
    public class BossProvider
    {
        public static void SendToDB(
            List<DordEntity> worker,
            List<StorageItemEntity> items,
            List<OrderDord> orders)
        {
            //sender.ChangeStorage(items);
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

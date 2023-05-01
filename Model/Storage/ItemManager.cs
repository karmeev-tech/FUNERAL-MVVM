using Infrastructure.Storage;

namespace Model.Storage
{
#nullable disable
    public class ItemManager
    {
        private readonly ShopItem _item;
        private readonly IShopRepos _manageItem;

        public ItemManager(ShopItem item,
            IShopRepos manageItem)
        {
            _item = item;
            _manageItem = manageItem;
        }

        public string AddItemToDB()
        {
            return _manageItem.AddItemToDB(_item);
        }
        public void RemoveItemFromDB()
        {

        }
        public string IdentityCheck()
        {
           return _manageItem.IdentityCheck(_item);
        }
    }
}

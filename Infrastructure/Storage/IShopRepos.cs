using Domain.Shop;
using System.Collections.ObjectModel;

namespace LegacyInfrastructure.Storage
{
    public interface IShopRepos
    {
        public string AddItemToDB(ShopItem item);
        public void UpdateDB(ShoppingItem item);
        public string IdentityCheck(ShopItem item);
        public List<string> GetItemNames();
        public ObservableCollection<ShopItem> GetItems();
        public List<string> GetPickLinks();
        public void DeleteInDB(string name);
        public void DeleteInWorkspace(string name);

        public void UpdateItemInDB(string name, int count);
    }
}

using System.Collections.ObjectModel;

namespace Infrastructure.Storage
{
    public interface IShopRepos
    {
        public string AddItemToDB(ShopItem item);
        public void UpdateDB(ShopItem item, string pickLink);
        public string IdentityCheck(ShopItem item);
        public List<string> GetItemNames();
        public ObservableCollection<ShopItem> GetItems();
        public List<string> GetPickLinks();
        public void DeleteInDB(string name);
        public void DeleteInWorkspace(string name);
    }
}

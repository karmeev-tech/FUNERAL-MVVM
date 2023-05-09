using Domain.Complect;
using Domain.Shop;
using Legacy.Infrastructure.Complect;
using LegacyInfrastructure.Complect;
using LegacyInfrastructure.Storage;

namespace Shop
{
    public class ShopProvider
    {
        private readonly IComplectRepos _complectRepos = new ComplectRepos();
        private readonly IShopRepos _shopRepos = new ShopRepos();

        public List<ItemComplectEntity> GetItems()
        {
            return new ShopStorage(_complectRepos,_shopRepos).GetItems();
        }

        public List<ShoppingItem> GetAllItems()
        {
            return new ShopStorage(_complectRepos,_shopRepos).GetAllItems();
        }

        public void UpdateItems(ShoppingItem item)
        {
            new ShopStorage(_complectRepos,_shopRepos).UpdateItems(item);
        }
    }
}
using Domain.Complect;
using Domain.Shop;

namespace Legacy.Infrastructure.Complect
{
    public interface IComplectRepos
    {
        public List<ItemComplectEntity> GetItems();
        public List<ShoppingItem> GetAllItems();
    }
}

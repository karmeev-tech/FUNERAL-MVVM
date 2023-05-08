using Domain.Complect;
using Legacy.Infrastructure.Complect;
using LegacyInfrastructure.Complect;

namespace Shop
{
    public class ShopProvider
    {
        private readonly IComplectRepos _complectRepos = new ComplectRepos();

        public List<ItemComplectEntity> GetItems()
        {
            return new ShopStorage(_complectRepos).GetItems();
        }
    }
}
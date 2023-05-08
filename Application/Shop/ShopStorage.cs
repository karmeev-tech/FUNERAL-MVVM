using Domain.Complect;
using Legacy.Infrastructure.Complect;

namespace Shop
{
    internal class ShopStorage
    {
        private readonly IComplectRepos _complectRepos;

        public ShopStorage(IComplectRepos complectRepos)
        {
            _complectRepos = complectRepos;
        }

        public List<ItemComplectEntity> GetItems()
        {
            return _complectRepos.GetItems();
        }
    }
}

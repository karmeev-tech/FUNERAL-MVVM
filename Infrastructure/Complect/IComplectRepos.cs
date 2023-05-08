using Domain.Complect;

namespace Legacy.Infrastructure.Complect
{
    public interface IComplectRepos
    {
        public List<ItemComplectEntity> GetItems();
    }
}

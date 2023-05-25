using Infrastructure.Model.Storage;

namespace Infrastructure.Model.Issue
{
    public class ItemsComplectEFentity
    {
        public int Id { get; set; }
        public List<StorageItemEntity> Items { get; set; }
    }
}

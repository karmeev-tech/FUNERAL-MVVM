using Infrastructure.Model.Storage;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model.ComplexMongo
{
    public class ItemsEntity
    {
        [Key]
        public int Id { get; set; }
        public List<StorageItemEntity> Complect { get; set; } = new List<StorageItemEntity>();
    }
}

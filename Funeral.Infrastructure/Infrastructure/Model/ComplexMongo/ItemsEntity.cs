using Domain.Complect;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model.ComplexMongo
{
    public class ItemsEntity
    {
        [Key]
        public int Id { get; set; }
        public List<ItemComplectEntity> Complect { get; set; } = new List<ItemComplectEntity>();
    }
}

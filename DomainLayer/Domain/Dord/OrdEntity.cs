using Domain.Complect;
using Domain.Order;
using Domain.Services.Entity;

namespace Domain.Dord
{
    public class OrdEntity
    {
        public List<Service>? Services { get; set; }
        public OrderEntity? Order { get; set; }
        public List<ItemComplectEntity>? ItemComplectEntities { get; set; }
    }
}

using Domain.Complect;
using Domain.Order;
using Domain.Services.Entity;

namespace Infrastructure.Model.ComplexMongo
{
    public class StateEntity
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public OrderEntity Order { get; set; } = new();
        public List<ItemComplectEntity> Complect { get; set; } = new();
        public List<Service> Services { get; set; } = new();
    }
}

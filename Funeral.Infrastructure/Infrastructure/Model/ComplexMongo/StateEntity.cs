using Domain.Order;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Model.ComplexMongo
{
    public class StateEntity
    {
        [BsonId]
        public int Id { get; set; }
        public string Time { get; set; }
        public string ManagerName { get; set; }
        public OrderEntity Order { get; set; }
        public ItemsEntity Complect { get; set; }
        public ComplexServiceEntity Services { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Model.Storage
{
    public class StorageItemEntity
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ZakupPrice { get; set; }
        public int Count { get; set; }
        public int Procent { get; set; }
        public string ShopName { get; set; }
    }
}

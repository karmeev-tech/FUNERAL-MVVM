using Domain.Complect;
using Domain.Dord;
using Domain.Order;
using Domain.Services.Entity;
using Domain.Shop;
using System.IO;
using System.Text.Json;

namespace BossInstruments
{
    public class OrdFormalizer
    {
        public static OrdEntity GetJson(string pathToJson)
        {
            OrdEntity entity = new OrdEntity();
            string json = "";
            using (StreamReader r = new StreamReader(pathToJson + @"\complect.json"))
            {
                json = r.ReadToEnd();
            }
            var result = JsonSerializer.Deserialize<List<ItemComplectEntity>>(json);
            entity.ItemComplectEntities = result;

            json = "";
            using (StreamReader r = new StreamReader(pathToJson + @"\order.json"))
            {
                json = r.ReadToEnd();
            }
            var result2 = JsonSerializer.Deserialize<OrderEntity>(json);
            entity.Order = result2;

            json = "";
            using (StreamReader r = new StreamReader(pathToJson + @"\services.json"))
            {
                json = r.ReadToEnd();
            }
            var result3 = JsonSerializer.Deserialize<List<Service>>(json);
            entity.Services = result3;
            return entity;
        }
    }
}

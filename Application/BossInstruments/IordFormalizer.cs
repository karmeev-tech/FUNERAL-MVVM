using Domain.Complect;
using Domain.Dord;
using Domain.Shop;
using System.Text.Json;

namespace BossInstruments
{
    public class IordFormalizer
    {
        public static IordEntity GetJson(string[] pathsToJson)
        {
            List<ItemComplectEntity> items = new();
            foreach (var path in pathsToJson)
            {
                string json = "";
                using (StreamReader r = new StreamReader(path))
                {
                    json = r.ReadToEnd();
                }
                var result = JsonSerializer.Deserialize<List<ItemComplectEntity>>(json);
                items = items.Concat(result).ToList();
            }

            IordEntity iordEntity = new();
            iordEntity.ShopItems = new();

            foreach(var item in items)
            {
                iordEntity.ShopItems.Add(new()
                {
                    Name = item.Name,
                    Price = item.Money,
                    ZakupPrice = 0,
                    Count = item.Count,
                    Procent = item.Procent
                });
            }

            return iordEntity;
        }

    }
}

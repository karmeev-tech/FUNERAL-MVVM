using Domain.Dord;
using Domain.GeneralOrder;
using Domain.Shop;
using System.Text.Json;

namespace BossInstruments
{
    public class DordMetaFormalizer
    {
        public static DordMeta GetJson(string pathsToJson)
        {
            string json = "";
            using (StreamReader r = new StreamReader(pathsToJson))
            {
                json = r.ReadToEnd();
            }

            return JsonSerializer.Deserialize<DordMeta>(json);
        }
    }
}

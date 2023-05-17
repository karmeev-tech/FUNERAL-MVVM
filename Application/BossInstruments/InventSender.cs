using Domain.Complect;
using Infrastructure.Model.Storage;
using System.Text.Json;

namespace BossInstruments
{
    public class InventSender
    {
        public void Send(List<StorageItemEntity> storageItemEntities)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SendJsonAsync(desktopPath, storageItemEntities);
        }
        public async void SendJsonAsync(string desktopPath, List<StorageItemEntity> storageItemEntities)
        {
            using FileStream createStream = File.Create(desktopPath + @"\invent.json");
            await JsonSerializer.SerializeAsync(createStream, storageItemEntities, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await createStream.DisposeAsync();
        }
        
        public List<StorageItemEntity> Get(string pathToJson)
        {
            string json = "";
            using (StreamReader r = new StreamReader(pathToJson))
            {
                json = r.ReadToEnd();
            }
            return JsonSerializer.Deserialize<List<StorageItemEntity>>(json);

        }
    }
}

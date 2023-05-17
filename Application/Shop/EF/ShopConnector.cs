using Infrastructure.Context.Storage;
using Infrastructure.Context.Worker;
using Infrastructure.Model.Storage;

namespace Shop.EF
{
    public class ShopConnector
    {
        public static List<string> GetShops() 
        {
            List<string> shops = new List<string>();

            using (var db = new StorageContext())
            {
                var query = from b in db.Storages
                            orderby b.Name
                            select b;

                foreach (var item in query)
                {
                    shops.Add(item.Name);
                }
            }
            return shops; 
        }
        public static StorageEntity GetShop(string shopName)
        {
            StorageEntity shop = null;
            using (var db = new StorageContext())
            {
                var query = from b in db.Storages
                            where b.Name == shopName
                            select b;
                shop = query.First();
            }
            return shop;
        }
        public static List<StorageItemEntity> GetStorageItems(string shopName)
        {
            List<StorageItemEntity> items = new List<StorageItemEntity>();

            using (var db = new StorageContext())
            {
                var query = from b in db.StorageItems
                            where b.ShopName.Name == shopName
                            select b;

                foreach (var item in query)
                {
                    items.Add(item);
                }
            }
            return items;
        }

        public void UpdateDB(List<StorageItemEntity> items, string shopName)
        {
            using (var db = new StorageContext())
            {
                int i = 0;
                foreach (var entity in db.StorageItems.Where(x => x.ShopName.Name == shopName))
                {
                    entity.ShopName = items[i].ShopName;
                    entity.Count = items[i].Count;
                    entity.Price = items[i].Price;
                    entity.ZakupPrice = items[i].ZakupPrice;
                    entity.Procent = items[i].Procent;
                    entity.Name = items[i].Name;
                    i++;
                }
                db.SaveChanges();
            }
        }

        public string AddShop(string shopName)
        {
            using (var db = new StorageContext())
            {
                var query = from b in db.Storages
                            orderby b.Name
                            where b.Name == shopName
                            select b;

                if(query.Any())
                {
                    return "error";
                }

                var entity = new StorageEntity { Name = shopName };
                db.Storages.Add(entity);
                db.SaveChanges();
            }

            return "ok";
        }

        public string DeleteShop(string shopName)
        {
            using (var db = new StorageContext())
            {
                var id = from b in db.Storages
                         orderby b.Id
                         where b.Name == shopName
                         select b.Id;

                var entity = db.Storages.Find(id.FirstOrDefault());
                if (entity != null)
                {
                    db.Storages.Remove(entity);
                    db.SaveChanges();
                    return "ok";
                }
                return "error";
            }
        }

        public static string GetUserStorage(string userName)
        {
            using (var db = new WorkerContext())
            {
                var query = from worker in db.Workers
                            where worker.Name == userName
                            select worker.ShopName.Name;

                return query.First();
            }
        }

        public static void InventUpdate(List<StorageItemEntity> storageItemEntities, string shopName)
        {
            using (var db = new StorageContext())
            {
                foreach (var storageItemEntity in storageItemEntities)
                {
                    var query = from b in db.StorageItems
                                where b.Name == storageItemEntity.Name && b.ShopName.Name == shopName
                                select b;

                    if (query.Any())
                    {
                        var item = query.First();
                        item.Count += storageItemEntities.Count;
                        if(item.Price != storageItemEntity.Price)
                        {
                            item.Price = storageItemEntity.Price;
                        }
                        if (item.ZakupPrice != storageItemEntity.ZakupPrice)
                        {
                            item.ZakupPrice = storageItemEntity.ZakupPrice;
                        }
                        if (item.Procent != storageItemEntity.Procent)
                        {
                            item.Procent = storageItemEntity.Procent;
                        }
                    }
                }

                db.SaveChanges();
            }

            using (var db = new StorageContext())
            {
                foreach (var storageItemEntity in storageItemEntities)
                {
                    var query = from b in db.StorageItems
                                where b.Name == storageItemEntity.Name && b.ShopName.Name == shopName
                                select b;

                    if (!query.Any())
                    {
                        db.StorageItems.Add(storageItemEntity);
                        db.SaveChanges();
                    }
                }

                db.SaveChanges();
            }

            var x = GetStorageItems(shopName);
        }
    }
}

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

            using (var db = new ShopsContext())
            {
                var query = from b in db.Shops
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
            using (var db = new ShopsContext())
            {
                var query = from b in db.Shops
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
                            where b.ShopName == shopName
                            select b;

                foreach (var item in query)
                {
                    items.Add(item);
                }
            }
            return items;
        }
        public static List<StorageItemEntity> GetAllStorageItems()
        {
            List<StorageItemEntity> items = new List<StorageItemEntity>();

            using (var db = new StorageContext())
            {
                var query = from b in db.StorageItems
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
                var updateItems = db.StorageItems.Where(x => x.ShopName == shopName).ToList();
                int i = 0;
                foreach (var entity in updateItems)
                {
                    db.StorageItems.Remove(entity);
                }

                foreach (var item in items)
                {
                    item.ShopName = ShopConnector.GetShop(shopName).Name;
                    db.StorageItems.Add(item);
                }

                db.SaveChanges();
            }
        }
        public string AddShop(string shopName)
        {
            using (var db = new ShopsContext())
            {
                var query = from b in db.Shops.Select(selector => selector.Name)
                            where b == shopName
                            select b;

                if (query.Any())
                {
                    return "error";
                }

                var query2 = from b in db.Shops
                             orderby b.Id
                             select b.Id;

                var id = query2.ToList().Last();

                db.Shops.Add(new StorageEntity() { Id = id + 1, Name = shopName });
                db.SaveChanges();
            }

            return "ok";
        }
        public string DeleteShop(string shopName)
        {
            using (var db = new ShopsContext())
            {
                var query = from shops in db.Shops
                            where shops.Name == shopName
                            select shops.Id;
                if (query.Any() && query.ToList().Count == 1)
                {
                    var shop = new StorageEntity() { Id = query.ToList().First(), Name = shopName };
                    db.Shops.Remove(shop);
                    db.SaveChanges();

                    using (var db2 = new StorageContext())
                    {
                        var query3 = from items in db2.StorageItems
                                     where items.ShopName == shopName
                                     select items;
                        db2.StorageItems.RemoveRange(query3.ToList());
                        db2.SaveChanges();
                    }

                    return "Удалён";
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
                            select worker.ShopName;

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
                                where b.Name == storageItemEntity.Name && b.ShopName == shopName
                                select b;

                    if (query.Any())
                    {
                        var item = query.First();
                        item.Count += storageItemEntity.Count;
                        if (item.Price != storageItemEntity.Price)
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
                                where b.Name == storageItemEntity.Name && b.ShopName == shopName
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
        public static void UpdateAllDB(List<StorageItemEntity> items)
        {
            using (var db = new StorageContext())
            {
                db.StorageItems.RemoveRange(db.StorageItems.ToList());
                foreach (var storageItemEntity in items)
                {
                    db.StorageItems.Add(storageItemEntity);
                }
                db.SaveChanges();
            }
        }
        public static void UpdateShopsAllDB(List<StorageEntity> items)
        {
            using (var db = new ShopsContext())
            {
                db.Shops.RemoveRange(db.Shops.ToList());
                foreach (var shopEntity in items)
                {
                    db.Shops.Add(shopEntity);
                }
                db.SaveChanges();
            }
        }
        public static void EditItemInShop(List<StorageItemEntity> items)
        {
            using (var db = new StorageContext())
            {
                var query = from item in db.StorageItems
                            select item;

                foreach (var workerItems in items)
                {
                    var storageItem = query.Where(x => x.Name == workerItems.Name && x.ShopName == workerItems.ShopName)
                         .Select(x => x.Count)
                         .First();
                    var sItem = query.Where(x => x.Name == workerItems.Name && x.ShopName == workerItems.ShopName)
                         .Select(x => x)
                         .First();

                    db.StorageItems.Remove(sItem);
                    db.SaveChanges();

                    storageItem -= workerItems.Count;
                    sItem.Count = storageItem;
                    db.StorageItems.Add(sItem);
                    db.SaveChanges();
                }
            }
        }
    }
}

using Infrastructure.Model.Storage;
using System.Data.Entity;

namespace Infrastructure.Context.Storage
{
    public class StorageContext : DbContext
    {
        public DbSet<StorageItemEntity> StorageItems { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
    }
}

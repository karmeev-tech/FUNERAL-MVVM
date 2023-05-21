using Infrastructure.Model.Storage;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Context.Storage
{
    public class StorageContext : DbContext
    {
        public DbSet<StorageItemEntity> StorageItems { get; set; }

        public string DbPath { get => ConfigurationManager.AppSettings["StorageDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

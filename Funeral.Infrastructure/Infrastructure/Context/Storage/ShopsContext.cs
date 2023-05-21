using Infrastructure.Model.Storage;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Context.Storage
{
    public class ShopsContext : DbContext
    {
        public DbSet<StorageEntity> Shops { get; set; }

        public string DbPath { get => ConfigurationManager.AppSettings["ShopDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

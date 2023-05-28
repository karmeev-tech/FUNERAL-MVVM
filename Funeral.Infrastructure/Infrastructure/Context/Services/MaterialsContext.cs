using Infrastructure.Model.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Context.Services
{
    public class MaterialsContext : DbContext
    {
        public DbSet<ServiceEntity> Materials { get; set; }
        public string DbPath { get => ConfigurationManager.AppSettings["MaterialsDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

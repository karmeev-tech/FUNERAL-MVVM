using Infrastructure.Model.Worker;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Context.Worker
{
    public class WorkerContext : DbContext
    {
        public DbSet<WorkerEntity> Workers { get; set; }

        public string DbPath { get => ConfigurationManager.AppSettings["WorkerDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

using Infrastructure.Model.ComplexMongo;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Context.State
{
    public class StateContext : DbContext
    {
        public DbSet<StateEntity> State { get; set; }

        public string DbPath { get => ConfigurationManager.AppSettings["StateDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

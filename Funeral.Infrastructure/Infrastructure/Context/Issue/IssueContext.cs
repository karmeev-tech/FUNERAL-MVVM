using Domain.Complect;
using Domain.Order;
using Domain.Services.Entity;
using Infrastructure.Model.Issue;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Context.Issue
{
    public class IssueContext : DbContext
    {
        public DbSet<IssueEntity> IssueMoney { get; set; }
        public DbSet<OrderEntity> IssueOrder { get; set; }
        public DbSet<ItemsComplectEFentity> IssueComplect { get; set; }
        public DbSet<ServiceComplectEFentity> Services { get; set; }

        public string DbPath { get => ConfigurationManager.AppSettings["IssueDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

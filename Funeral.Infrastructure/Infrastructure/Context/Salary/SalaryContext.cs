using Infrastructure.Model.Issue;
using Infrastructure.Model.Salary;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure.Context.Salary
{
    public class SalaryContext : DbContext
    {
        public DbSet<SalaryEntity> IssueMoney { get; set; }
        public string DbPath { get => ConfigurationManager.AppSettings["SalaryDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

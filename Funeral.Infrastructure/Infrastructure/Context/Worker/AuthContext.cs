using Infrastructure.Model.Worker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Worker
{
    public class AuthContext : DbContext
    {
        public DbSet<AuthEntity> Auth { get; set; }
        public string DbPath { get => ConfigurationManager.AppSettings["AuthDB"]; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}

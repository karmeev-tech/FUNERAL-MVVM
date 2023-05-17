using Infrastructure.Model.Storage;
using Infrastructure.Model.Worker;
using System.Data.Entity;

namespace Infrastructure.Context.Worker
{
    public class WorkerContext : DbContext
    {
        public DbSet<WorkerEntity> Workers { get; set; }
    }
}

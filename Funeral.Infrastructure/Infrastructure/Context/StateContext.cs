using Infrastructure.Model.ComplexMongo;
using System.Data.Entity;

namespace Infrastructure.Context
{
    public class StateContext : DbContext
    {
        public DbSet<StateEntity> State { get; set; }
    }
}

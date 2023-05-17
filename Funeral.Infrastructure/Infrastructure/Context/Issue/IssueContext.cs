using Infrastructure.Model.Issue;
using System.Data.Entity;

namespace Infrastructure.Context.Issue
{
    public class IssueContext : DbContext
    {
        public DbSet<IssueEntity> IssueMoney { get; set; }
    }
}

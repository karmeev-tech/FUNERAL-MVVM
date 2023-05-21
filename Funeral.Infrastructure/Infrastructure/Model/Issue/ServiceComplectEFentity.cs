using Domain.Services.Entity;

namespace Infrastructure.Model.Issue
{
    public class ServiceComplectEFentity
    {
        public int Id { get; set; }
        public List<Service> Services { get; set; }
    }
}

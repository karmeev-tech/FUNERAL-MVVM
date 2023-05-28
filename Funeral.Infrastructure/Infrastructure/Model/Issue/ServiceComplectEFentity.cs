using Infrastructure.Model.Services;

namespace Infrastructure.Model.Issue
{
    public class ServiceComplectEFentity
    {
        public int Id { get; set; }
        public List<ServiceEntity> Services { get; set; }
    }
}

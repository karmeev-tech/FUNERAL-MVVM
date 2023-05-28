using Infrastructure.Model.Services;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model.ComplexMongo
{
    public class ComplexServiceEntity
    {
        [Key]
        public int Id { get; set; }
        public List<ServiceEntity> Services { get; set; } = new List<ServiceEntity>();
    }
}

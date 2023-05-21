using Domain.Services.Entity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model.ComplexMongo
{
    public class ComplexServiceEntity
    {
        [Key]
        public int Id { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
    }
}

using System.Data.Linq.Mapping;

namespace ClassLibrary.Domain
{
    [Table(Name = "Salary")]
    public class BaseSalary
    {
        [Column(IsPrimaryKey = true, Storage = "Id")]
        public int Id { get; set; }
        [Column(Storage = "Name")]
        public string Name { get; set; }
        [Column(Storage = "Money")]
        public int Money { get; set; }
    }
}

namespace Infrastructure.Model.Services
{
    public class ServiceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Money { get; set; }
        public int Count { get; set; }
        public string Param1 { get; set; } = string.Empty;
    }
}

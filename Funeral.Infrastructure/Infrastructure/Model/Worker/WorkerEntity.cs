namespace Infrastructure.Model.Worker
{
    public class WorkerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Passport { get; set; }
        public string Contacts { get; set; }
        public string Credentials { get; set; }
        public string Role { get; set; } = "Сотрудник";
        public string ShopName { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}

namespace Domain.Main
{
    // Сущность для загрузки отчёта (босс)
    public class MainEntity
    {
        public string ManagerName { get; set; } = string.Empty;
        public string StartWorkTime { get; set; } = string.Empty;
        public string EndWorkTime { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty; // это оклад
        public string Money { get; set; } = string.Empty; // зп
    }
}

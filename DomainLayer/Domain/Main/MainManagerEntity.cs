namespace Domain.Main
{
    // сущность с отчётом кассира
    public class MainManagerEntity
    {
        public string ManagerName { get; set; } = string.Empty;
        public string StartWorkTime { get; set; } = string.Empty;
        public string EndWorkTime { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty; // это оклад
        public string Money { get; set; } = string.Empty; // зп
        public List<string> FuneralSell { get; set; } = new(); // проданные гробы
        public List<string> LinksToScans { get; set; } = new();
    }

    public static class IssueProcess
    {
        public static MainEntity ToMainEntity(this MainManagerEntity entity)
        {
            return new MainEntity()
            {
                ManagerName = entity.ManagerName,
                StartWorkTime = entity.StartWorkTime,
                EndWorkTime = entity.EndWorkTime,
                Salary = entity.Salary,
                Money = entity.Money
            };
        }
    }
}

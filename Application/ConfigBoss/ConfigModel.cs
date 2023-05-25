using Infrastructure.Model.Salary;
using Infrastructure.Model.Storage;
using Infrastructure.Model.Worker;

namespace ConfigBoss
{
    public class ConfigModel
    {
        public List<string> Shops { get; set; }
        public List<StorageItemEntity> ShopsItems { get; set; }
        public List<WorkerEntity> Workers { get; set; }
        public List<SalaryEntity> Salary { get; set; }
    }
}

using Domain.Shop;
using LegacyInfrastructure.Salary;
using LegacyInfrastructure.Storage;

namespace BossInstruments
{
    public class DBSender
    {
        private readonly IShopRepos _shopRepos;
        private readonly SalaryManager _salaryManager;
        public DBSender(IShopRepos shopRepos, SalaryManager salaryManager)
        {
            _shopRepos = shopRepos;
            _salaryManager = salaryManager;
        }

        public void ChangeStorage(List<ShoppingItem> items)
        {
            foreach (ShoppingItem item in items)
            {
                _shopRepos.UpdateItemInDB(item.Name,item.Count);
            }
        }

        public void ChangeSalary(string name, int money)
        {
            _salaryManager.UpdateSalary(name,money);
        }
    }
}

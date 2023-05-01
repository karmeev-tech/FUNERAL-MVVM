using Domain.Salary;
using Infrastructure.Connector;

namespace Infrastructure.Salary
{
    public class SalaryManager : GenConnector
    {
        private readonly WorkerSalary _baseSalary;

        public SalaryManager(WorkerSalary baseSalary)
        {
            _baseSalary = baseSalary;
        }

        public void UpdateSalary()
        {
            Connect("SalaryDB");
        }
    }
}

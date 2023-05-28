using FUNERAL_MVVM.Utility;
using System.Linq;
using Worker.EF;

namespace FUNERALMVVM.ViewModel.Workers
{
    public class WorkerController : ViewModelBase
    {
        public WorkerController()
        {
            //сбор всех сотрудников из базы
            //нужно обеспечение из журнала посещения последнее имя
            var worker = WorkerConnector.GetLastLoginWorker().Worker;
            string salary = "";
            try
            {
                salary = WorkerConnector.GetAllSalary().Where(x => x.WorkerName == worker).ToList().First().WorkerMoney.ToString();
            }
            catch
            {
                salary = "";
            }

            WorkerSalary = salary;
            WorkerStatus = WorkerConnector.GetWorkerRole(worker);
            WorkerProcent = "1000";

            if (WorkerStatus == "Сотрудник")
            {
                IsEnabled = false;
            }
        }

        private string _status = string.Empty;
        public string WorkerStatus
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(WorkerStatus));
            }
        }
        public string WorkerMoney { get; set; }
        public string WorkerSalary { get; set; }
        public string WorkerProcent { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}

using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using LegacyInfrastructure.Worker;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Windows.Input;
using Worker;
using Worker.EF;

namespace FUNERALMVVM.ViewModel.Workers
{
    public class WorkerController : ViewModelBase
    {
        public WorkerController(IWorkerRepos workerContext)
        {
            //сбор всех сотрудников из базы
            //нужно обеспечение из журнала посещения последнее имя
            var worker = workerContext.GetLastFromJournal();

            //WorkerMoney = WorkerConnector.GetAllSalary().Where(x => x.WorkerName == worker).Select(x => x.WorkerMoney).First().ToString();
            WorkerSalary = "0";
            WorkerStatus = WorkerConnector.GetWorkerRole(worker);
            WorkerProcent = "0";

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

using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using LegacyInfrastructure.Worker;
using System.Windows.Input;
using Worker;

namespace FUNERALMVVM.ViewModel
{
    public class WorkerController : ViewModelBase
    {
        //public IWorkerRepos WorkerContext { get; }
        public WorkerController(IWorkerRepos workerContext)
        {
            //сбор всех сотрудников из базы
            //нужно обеспечение из журнала посещения последнее имя
            var worker = workerContext.GetLastFromJournal();

            WorkerProvider workerProvider = new();

            WorkerMoney = "0";
            WorkerSalary = "0";
            WorkerStatus = workerProvider.GetWorkerRole(worker);
            WorkerProcent = "0";

            if(WorkerStatus == "Сотрудник")
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

using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using LegacyInfrastructure.Worker;
using System.Windows.Input;

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

            WorkerMoney = "0";
            WorkerSalary = "0";
            WorkerStatus = workerContext.GetLastRoleFromJournal(worker);
            WorkerProcent = "0";
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

        #region COMMANDS
        public ICommand AddCommand => new AddWorkerCommand(this);
        public ICommand FireCommand => new FireWorkerCommand(this);
        #endregion
    }
}

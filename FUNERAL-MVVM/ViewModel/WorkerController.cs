using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using Infrastructure.Worker;
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
            var workerInfo = workerContext.GetWorkerInfo("name");
            WorkerMoney = workerInfo[0];
            WorkerSalary = workerInfo[1];
            WorkerStatus = workerInfo[2];
            WorkerProcent = workerInfo[3];
        }

        public string WorkerStatus { get; set; }
        public string WorkerMoney { get; set; }
        public string WorkerSalary { get; set; }
        public string WorkerProcent { get; set; }

        #region COMMANDS
        public ICommand AddCommand => new AddWorkerCommand(this);
        public ICommand FireCommand => new FireWorkerCommand(this);
        #endregion
    }
}

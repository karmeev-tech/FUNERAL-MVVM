using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using FUNERALMVVM.View.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Worker;

namespace FUNERALMVVM.ViewModel
{
    public class DeleteWorkersVM : ViewModelBase
    {
        private DeleteWorkerWindow DeleteWorker;

        public DeleteWorkersVM(DeleteWorkerWindow deleteWorker)
        {
            DeleteWorker = deleteWorker;
            WorkerProvider workerProvider = new WorkerProvider();
            foreach (string workerName in workerProvider.GetWorkers())
            {
                workers.Add(workerName);
            }
        }

        public ObservableCollection<string> workers { get; set; } = new();
        public string SelectedWorker { get; set; }
        public ICommand Delete => new FireWorkerCommand(this);

        public void Closing()
        {
            DeleteWorker.Close();
        }
    }
}

using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using FUNERALMVVM.View.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Worker;
using Worker.EF;

namespace FUNERALMVVM.ViewModel.Workers
{
    public class DeleteWorkersVM : ViewModelBase
    {
        private DeleteWorkerWindow DeleteWorker;
        private ObservableCollection<string> _workers = new();

        public DeleteWorkersVM(DeleteWorkerWindow deleteWorker)
        {
            DeleteWorker = deleteWorker;
            foreach (string workerName in WorkerConnector.GetWorkers().Select(x => x.Name))
            {
                Workers.Add(workerName);
            }
        }

        public ObservableCollection<string> Workers { get => _workers; set { _workers = value; OnPropertyChanged(nameof(Workers)); } }
        public string SelectedWorker { get; set; }
        public ICommand Delete => new FireWorkerCommand(this);

        public void Closing()
        {
            DeleteWorker.Close();
        }
    }
}

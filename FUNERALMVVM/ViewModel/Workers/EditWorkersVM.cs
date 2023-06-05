using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View.Windows;
using Infrastructure.Model.Worker;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Worker.EF;

namespace FUNERALMVVM.ViewModel.Workers
{
    public class EditWorkersVM : ViewModelBase
    {
        public ObservableCollection<WorkerEntity> _workers = new();
        public EditWorkersWindow _editWorkersWindow;
        public EditWorkersVM(EditWorkersWindow editWorkersWindow)
        {
            Workers = new ObservableCollection<WorkerEntity>(WorkerConnector.GetWorkers());
            _editWorkersWindow = editWorkersWindow;
        }

        public ObservableCollection<WorkerEntity> Workers 
        {
            get => _workers; 
            set
            {
                _workers = value;
                OnPropertyChanged(nameof(Workers));
            }
        }

        public ICommand Edit => new EditWorkerCommand(this);

        public void OnClosed()
        {
            _editWorkersWindow.Close();
        }

    }
}

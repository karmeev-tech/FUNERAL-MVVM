using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel.Workers;
using IssueProvider;
using Worker.EF;

namespace FUNERALMVVM.Commands.Workers
{
    internal class FireWorkerCommand : BaseCommands
    {
        private readonly DeleteWorkersVM _vm;

        public FireWorkerCommand(DeleteWorkersVM vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            try
            {
                WorkerConnector.DeleteWorker(_vm.SelectedWorker);
                IssueCenter.DeleteSalary(_vm.SelectedWorker);
                _vm.Closing();
            }
            catch
            {
                return;
            }
        }
    }
}

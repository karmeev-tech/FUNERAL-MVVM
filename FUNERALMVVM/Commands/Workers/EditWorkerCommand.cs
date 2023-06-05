using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel.Workers;
using System.Linq;
using System.Windows.Input;
using Worker.EF;

namespace FUNERALMVVM
{
    public class EditWorkerCommand : BaseCommands
    {
        private EditWorkersVM _vm;

        public EditWorkerCommand(EditWorkersVM vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            if(_vm.Workers.ToList().Count != 0)
            {
                WorkerConnector.EditWorker(_vm.Workers.ToList());
                _vm.OnClosed();
            }
        }
    }
}
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel.Workers;
using Worker.EF;

namespace FUNERALMVVM.Commands.Workers
{
    internal class FireWorkerCommand : BaseCommands
    {
        private readonly DeleteWorkersVM _context;

        public FireWorkerCommand(DeleteWorkersVM context)
        {
            _context = context;
        }

        public override void Execute(object parameter)
        {
            WorkerConnector.DeleteWorker(_context.SelectedWorker);
            _context.Closing();
        }
    }
}

using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Worker;

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
            WorkerProvider workerProvider = new();
            workerProvider.DeleteWorker(_context.SelectedWorker);
            _context.Closing();
        }
    }
}

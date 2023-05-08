using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;

namespace FUNERALMVVM.Commands.Workers
{
    internal class FireWorkerCommand : BaseCommands
    {
        private readonly WorkerController _context;

        public FireWorkerCommand(WorkerController context)
        {
            _context = context;
        }

        public override void Execute(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}

using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Worker;
using Model.Worker;
using System.Threading.Tasks;

namespace FUNERALMVVM.Commands.Workers
{
    internal class AuthenticationCommand : BaseCommands
    {
        private readonly AuthenticationController _controller;
        private readonly IWorkerRepos _workerRepos = new WorkerRepos();
        public AuthenticationCommand(AuthenticationController controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
            //he is authorized
            Auth auth = new(_controller.Name, _controller.Password);

            //if this thing return not okay fucked up
            Check(auth);
        }
        public async void Check(Auth auth)
        {
            await Task.Run(() =>
            {
                _controller.Response = auth.TryAuth(_workerRepos);
            });
        }
    }
}


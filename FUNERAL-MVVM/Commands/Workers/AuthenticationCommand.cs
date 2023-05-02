using FUNERAL_MVVM;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Worker;
using Model.Worker;
using System.Threading;
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
            _controller.Response = auth.TryAuth(_workerRepos);

            if (_controller.Response is "ok")
            {
                WorkWindow workWindow = new();
                workWindow.Show();
                _controller._mainWindow.Close();
            }
        }
    }
}


using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using Worker;

namespace FUNERALMVVM.Commands.Workers
{
    internal class AuthenticationCommand : BaseCommands
    {
        private readonly AuthenticationController _controller;
        public AuthenticationCommand(AuthenticationController controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
            WorkerProvider workerProvider = new();
            _controller.Response = workerProvider.Auth(_controller.Name, _controller.Password);

            if (_controller.Response is "ok")
            {
                WorkWindow workWindow = new();
                workWindow.Show();
                _controller._mainWindow.Close();
            }
        }
    }
}


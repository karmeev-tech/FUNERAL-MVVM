using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using Worker.EF;

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
            _controller.Response = WorkerConnector.Auth(_controller.Name, _controller.Password);

            if (_controller.Response is "ok")
            {
                string role = WorkerConnector.GetWorkerRole(_controller.Name);
                WorkerConnector.AuthSend(_controller.Name);
                WorkWindow workWindow = new();
                workWindow.Show();
                if (role == "Сотрудник")
                {
                    workWindow.UploadDORD.IsEnabled = false;
                    workWindow.StorageHead.IsEnabled = false;

                    workWindow.UploadDORD.Content = "";
                    workWindow.StorageHead.Content = "";
                }
                _controller._mainWindow.Close();
            }
        }
    }
}


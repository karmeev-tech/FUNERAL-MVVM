using FUNERAL_MVVM;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using FUNERALMVVM.View;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class AuthenticationController : ViewModelBase
    {
        private string _response = null!;
        public MainWindow _mainWindow;

        public AuthenticationController(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Response 
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
                //OnOpenWorkSpace();
            }
        }
        #region COMMANDS    
        public ICommand AuthCommand => new AuthenticationCommand(this);
        #endregion

        public void OpenWork()
        {
            if (Response is "ok")
            {
                WorkWindow workWindow = new();
                workWindow.Show();
                _mainWindow.Close();
            }
        }
    }
}

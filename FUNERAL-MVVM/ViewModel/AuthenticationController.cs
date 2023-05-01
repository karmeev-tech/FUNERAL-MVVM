using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using Infrastructure.Worker;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class AuthenticationController : ViewModelBase
    {
        private string _response = null!;

        public AuthenticationController()
        {
            
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
            }
        }
        #region COMMANDS    
        public ICommand AuthCommand => new AuthenticationCommand(this);
        #endregion
    }
}

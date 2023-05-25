using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using FUNERALMVVM.View.Windows;
using Shop.EF;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel.Workers
{
#nullable disable
    public class RegistrationController : ViewModelBase
    {
        private AddWorkersWindow _addWorkersWindow;
        public RegistrationController(AddWorkersWindow addWorkersWindow)
        {
            Shops = new ObservableCollection<string>(ShopConnector.GetShops());
            _addWorkersWindow = addWorkersWindow;
        }

        private string _error;
        private string _status = string.Empty;
        private ObservableCollection<string> _shops;

        public string Error
        {
            get => _error; set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }
        public ICommand AddWorker => new RegistrationWorkerCommand(this);
        public string Name { get; set; } = "ФИО сотрудника";
        public string Adress { get; set; } = "Адрес сотрудника";
        public string Passport { get; set; } = "Паспорт";
        public string Contacts { get; set; } = "Контакты";
        public string Credentials { get; set; } = "Реквизиты";
        public string Role { get; set; } = string.Empty;
        public string Status { get => _status; set => _status = value; }
        public string Password { get; set; } = "Пароль";
        public ObservableCollection<string> Shops
        {
            get => _shops; set
            {
                _shops = value;
                OnPropertyChanged(nameof(Shops));
            }
        }

        public void Closing()
        {
            _addWorkersWindow.Close();
        }
    }
}

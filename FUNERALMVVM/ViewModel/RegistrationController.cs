using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Workers;
using FUNERALMVVM.View.Windows;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
#nullable disable
    public class RegistrationController : ViewModelBase
    {
        private AddWorkersWindow _addWorkersWindow;
        public RegistrationController(AddWorkersWindow addWorkersWindow)
        {
            _addWorkersWindow = addWorkersWindow;
        }

        private string _error;
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
        public string Role { get; set; } = "Сотрудник";
        public string Status { get; set; } = "Уволен/Не уволен";
        public string Password { get; set; } = "Пароль";

        public void Closing()
        {
            _addWorkersWindow.Close();
        }
    }
}

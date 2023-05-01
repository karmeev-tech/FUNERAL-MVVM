using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Storage;
using FUNERALMVVM.Commands.Workers;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
#nullable disable
    public class RegistrationController : ViewModelBase
    {
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
        public string Password { get; set; } = "Пароль";
        public string Role { get; set; } = "Сотрудник";

    }
}

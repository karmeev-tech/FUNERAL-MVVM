using Domain.Main;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Main;
using LegacyInfrastructure.Worker;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Worker.EF;

namespace FUNERALMVVM.ViewModel
{
    public class UsersController : ViewModelBase
    {
        private ObservableCollection<MainEntity> _bossTable = new();
        private string _userName;
        private string _role;
        private string _salary = string.Empty;
        private string _money = string.Empty;

        public UsersController()
        {
            WorkerRepos workerRepos = new WorkerRepos();
            UserName = workerRepos.GetLastFromJournal();
            Role = WorkerConnector.GetWorkerRole(UserName);
        }

        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } } // это manager name
        public string Role { get => _role; set { _role = value; OnPropertyChanged(nameof(Role)); } }
        public string StartWorkTime { get; set; } = string.Empty;
        public string EndWorkTime { get; set; } = string.Empty;
        public string Salary { get => _salary; set { _salary = value; OnPropertyChanged(nameof(Salary)); } }
        public string Money { get => _money; set { _money = value; OnPropertyChanged(nameof(Money)); } }
        public List<string> FuneralSell { get; set; } = new(); // проданные гробы
        public List<string> LinksToScans { get; set; } = new();


        public ObservableCollection<MainEntity> BossTable
        {
            get => _bossTable; set
            {
                _bossTable = value;
                OnPropertyChanged(nameof(BossTable));
            }
        }

        public ICommand SendCommand => new MainRequestCommand(this);
        public ICommand GetCommand => new MainResponseCommand(this);
    }
}

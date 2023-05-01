using Domain.Main;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Main;
using Infrastructure.Worker;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class UsersController : ViewModelBase
    {
        private ObservableCollection<MainEntity> _bossTable = new();

        public UsersController()
        {
            WorkerRepos workerRepos = new WorkerRepos();

            UserName = workerRepos.GetLastFromJournal();
            Role = workerRepos.GetLastRoleFromJournal(UserName);
        }

        public string UserName { get; set; } // это manager name
        public string Role { get; set; }
        public string StartWorkTime { get; set; } = string.Empty;
        public string EndWorkTime { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty; // это оклад
        public string Money { get; set; } = string.Empty; // зп
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

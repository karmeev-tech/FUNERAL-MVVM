using Domain.Services.Entity;
using FUNERAL_MVVM.Utility;
using FuneralClient.Commands.Services;
using FuneralClient.View.Windows;
using FUNERALMVVM.Commands.Services;
using Legacy.Infrastructure.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class ServicesController : ViewModelBase
    {
        private ServicesWindow _ordersWindow;

        private readonly ServiceRepos _complectRepos = new();
        public readonly List<Service> _listComplect;
        private string _exception;
        private ObservableCollection<string> _servicesName = new();
        private ObservableCollection<string> _paramsNames = new();
        private ObservableCollection<string> _paramsNames2 = new();
        private ObservableCollection<Service> _services = new();
        public ServicesController(ServicesWindow ordersWindow)
        {
            _ordersWindow = ordersWindow;
            _listComplect = _complectRepos.GetServices();

            List<string> names = _complectRepos.GetServicesByName();
            var servicesNames = names.Distinct().ToList();

            foreach (var item in servicesNames)
            {
                ServicesName.Add(item);
            }
        }

        private string chooseService = string.Empty;
        public string ChooseService 
        {
            get
            {
                return chooseService;
            } 
            set
            {
                chooseService = value;
                if (chooseService != string.Empty)
                {
                    var paramsNames = _listComplect.Where(item => item.Name == chooseService).Select(item => item.Param1).ToList();

                    ParamsNames = new();
                    foreach (var item in paramsNames)
                    {
                        ParamsNames.Add(item);
                    }

                    paramsNames = _listComplect.Where(item => item.Name == chooseService).Select(item => item.Param2).ToList();

                    ParamsNames2 = new();
                    foreach (var item in paramsNames)
                    {
                        ParamsNames2.Add(item);
                    }
                }
            }
        }
        public string ChooseParam { get; set; }
        public string ChooseParam2 { get; set; }

        public ObservableCollection<string> ServicesName
        {
            get => _servicesName;
            set
            {
                _servicesName = value;
                OnPropertyChanged(nameof(ServicesName));
            }
        }

        public ObservableCollection<string> ParamsNames 
        {
            get => _paramsNames;
            set 
            {
                _paramsNames = value;
                OnPropertyChanged(nameof(ParamsNames));
            } 
        }

        public ObservableCollection<string> ParamsNames2
        {
            get => _paramsNames2;
            set
            {
                _paramsNames2 = value;
                OnPropertyChanged(nameof(ParamsNames2));
            }
        }

        public ObservableCollection<Service> Services
        {
            get => _services;
            set
            {
                _services = value;
                OnPropertyChanged(nameof(Services));
            }
        }

        public string Exception
        {
            get => _exception; set
            {
                _exception = value;
                OnPropertyChanged(nameof(Exception));
            }
        }

        public ICommand AddServCommand => new AddServCommand(this);
        public ICommand ChooseServCommand => new AddServiceCommand(this);

        public void ViewClosed()
        {
            _ordersWindow.Opacity = 0;
            _ordersWindow.Close();
        }
        public void DeleteItem(string itemName)
        {
            var newItems = Services.Where(x => x.Name == itemName).ToList();
            foreach (var item in newItems)
            {
                Services.Remove(item);
            }
        }
    }
}

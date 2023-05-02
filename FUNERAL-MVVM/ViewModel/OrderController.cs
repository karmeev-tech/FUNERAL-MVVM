using Domain.Order;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Orders;
using LegacyInfrastructure.Storage;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class OrderController : ViewModelBase
    {
        private readonly IShopRepos _shopRepos = new ShopRepos();
        private string _services;
        private string _allServices;
        private string _complect;
        private string _price;

        public OrderController()
        {
            Price = "0";
            Prepayment = "0";

            foreach (var item in _shopRepos.GetItemNames())
            {
                Funerals.Add(item);
            }
        }

        //order
        public string FuneralSize { get; set; }
        public string UpDesign { get; set; }
        public string DownDesign { get; set; }
        public string OtherDesign { get; set; }
        public string Epitafia { get; set; }
        public string Funeral { get; set; } = "Funeral not available";
        public string Service { get; set; } = "Service not available";
        //client
        public string ClientFIO { get; set; }
        public string ClientAdress { get; set; }
        public string ClientNumber { get; set; }
        public string ClientFuneral { get; set; }
        public string ClientSocial { get; set; }
        public string ClientPassport { get; set; }
        //price
        public string Price { 
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string Prepayment { get; set; }
        public ICommand AddOrder => new AddOrderCommand(this);
        public ICommand AddServices => new AddServicesCommand(this);
        public ICommand GetServices => new GetServicesCommand(this);
        public ICommand AddComplect => new AddOrderComplectCommand(this);
        public ICommand GetComplect => new GetComplectCommand(this);
        public ICommand AddDeadBody => new AddDeadsCommand();
        public ICommand GetDeadBody => new GetDeadsCommand(this);
        public ICommand UpdateFunerals => new UpdateFuneralsCommand(this);
        public ObservableCollection<string> Funerals { get; set; } = new();
        //services
        public string Services
        {
            get => _services;
            set
            {
                _services = value;
                OnPropertyChanged(nameof(Services));
            }
        }
        public string AllServices
        {
            get => _allServices;
            set
            {
                _allServices = value;
                OnPropertyChanged(nameof(AllServices));
            }
        }

        public string Complect
        {
            get => _complect;
            set
            {
                _complect = value;
                OnPropertyChanged(nameof(Complect));
            }
        }

        private string _deadbody;
        public string Deadbody
        {
            get => _deadbody;
            set
            {
                _deadbody = value;
                OnPropertyChanged(nameof(Deadbody));
            }
        }

        public List<DeadEntity> _deadEntities;

        public int FuneralPrice { get; set; }
        public int ServsPrice { get; set; } = 0;
    }
}

using DocumentFormat.OpenXml.Office2010.ExcelAc;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Orders;
using LegacyInfrastructure.Storage;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Some.Add("hui");
        }

        #region Funeral Params
        public string FuneralSize { get; set; }
        public string UpDesign { get; set; }
        public string DownDesign { get; set; }
        public string OtherDesign { get; set; }
        public string Epitafia { get; set; }
        public string Looks { get; set; }
        #endregion

        #region Client
        public string ClientFIO { get; set; }
        public string ClientAdress { get; set; }
        public string ClientNumber { get; set; }
        public string ClientFuneral { get; set; }
        public string ClientSocial { get; set; }
        public string ClientPassport { get; set; }
        #endregion

        #region DEADS
        public int _deadboydCount = 0;
        private string _deadbody;
        private string _fIOdeads;
        private string _birthDeads;
        private string _deathDeads;
        public string FIOdeads { get => _fIOdeads;
            set 
            {
                _fIOdeads = value;
                OnPropertyChanged(nameof(FIOdeads));
            } 
        }
        public string BirthDeads { get => _birthDeads;
            set 
            {
                _birthDeads = value;
                OnPropertyChanged(nameof(BirthDeads));
            } 
        }
        public string DeathDeads { get => _deathDeads;
            set 
            {
                _deathDeads = value;
                OnPropertyChanged(nameof(DeathDeads));
            }
        }
        public string Deadbody
        {
            get => _deadbody;
            set
            {
                _deadbody = value;
                OnPropertyChanged(nameof(Deadbody));
            }
        }

        public List<string> _deadsCollection = new();
        #endregion

        #region Price
        public int FuneralPrice { get; set; } = 0;
        public int ServsPrice { get; set; } = 0;

        //price
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string Prepayment { get; set; }
        public string Remainder { get; set; }
        #endregion

        #region HeadPart
        public string FuneralCategory { get; set; }
        public string FuneralModel { get; set; }
        public string FuneralRock { get; set; }
        public string StelaSize { get; set; }
        public string StelaSection { get; set; }
        public string StandSize { get; set; }
        public string StandSection { get; set; }
        public string FlowerSize { get; set; }
        public string FlowerSection { get; set; }
        public string FlowerIndicate { get; set; } = "False";
        public string PolishingColor { get; set; }
        public string InstalPrice { get; set; }
        public string InstalIndicate { get; set; } = "False";
        public ObservableCollection<string> Some { get; set; } = new();
        #endregion

        public ICommand AddOrder => new AddOrderCommand(this);
        public ICommand AddServices => new AddServicesCommand(this);
        public ICommand AddComplect => new AddOrderComplectCommand(this);
        public ICommand AddDeads => new AddDeadsCommand(this);
        public ICommand DeleteLastDead => new DeleteLastDeadCommand(this);
    }
}

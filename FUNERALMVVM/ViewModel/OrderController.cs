using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Orders;
using FUNERALMVVM.Model.Order;
using FUNERALMVVM.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class OrderController : ViewModelBase
    {
        private string _services;
        private string _allServices;
        private string _complect;
        private string _price = string.Empty;
        public OrderPage _orderPage;
        public OrderController(OrderPage orderPage)
        {
            Price = "0";
            Prepayment = "0";
            Remainder = "0";
            _orderPage = orderPage;

#if DBG
            OneTimeNotFagot();
            OnPropertyChanged();
#endif
        }

        #region Funeral Params
        public string FuneralSize { get; set; } = string.Empty;
        public string UpDesign { get; set; } = string.Empty;
        public string DownDesign { get; set; } = string.Empty;
        public string OtherDesign { get; set; } = string.Empty;
        public string Epitafia { get; set; } = string.Empty;
        public string Looks { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        #endregion  

        #region Client
        public string ClientName { get; set; } = string.Empty;
        public string ClientLastName { get; set; } = string.Empty;
        public string ClientThirdName { get; set; } = string.Empty;
        public string ClientAdress { get; set; } = string.Empty;
        public string ClientNumber { get => _clientNumber; set { _clientNumber = value; ClientSocial = value; OnPropertyChanged(nameof(ClientNumber)); } }
        public string ClientFuneral { get; set; } = string.Empty;
        public string ClientSocial { get => _clientSocial; set { _clientSocial = value; OnPropertyChanged(nameof(ClientSocial)); } }
        public string ClientPassport { get; set; } = string.Empty;
        public string ClientDelivery { get; set; } = string.Empty;
        public string CreateFuneralDate
        {
            get => _createFuneralDate;
            set
            {
                _createFuneralDate = ErrorInput(value);
                OnPropertyChanged(nameof(CreateFuneralDate));
            }
        }


        private string _clientNumber = string.Empty;
        private string _clientSocial = string.Empty;
        private string _createFuneralDate = string.Empty;
        #endregion

        #region DEADS
        public int _deadboydCount = 0;
        private string _deadbody = string.Empty;
        private string _fIOdeads;
        private string _birthDeads;
        private string _deathDeads;
        public string FIOdeads
        {
            get => _fIOdeads;
            set
            {
                _fIOdeads = value;
                OnPropertyChanged(nameof(FIOdeads));
            }
        }
        public string BirthDeads
        {
            get => _birthDeads;
            set
            {
                _birthDeads = value;
                OnPropertyChanged(nameof(BirthDeads));
            }
        }
        public string DeathDeads
        {
            get => _deathDeads;
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

        public string Name
        {
            get => _name; set
            {
                _name = value; OnPropertyChanged(nameof(Name));
            }
        }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }
        public string ThirdName { get => _thirdName; set { _thirdName = value; OnPropertyChanged(nameof(ThirdName)); } }

        public List<string> _deadsCollection = new();
        public List<DeadModel> _deadModels = new();
        private string _name = string.Empty;
        private string _lastName = string.Empty;
        private string _thirdName = string.Empty;
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
        public string Prepayment { get; set; } = string.Empty;
        public string Remainder { get; set; } = string.Empty;
        #endregion

        #region HeadPart
        public string FuneralCategory { get; set; } = string.Empty;
        public string FuneralModel { get; set; } = string.Empty;
        public string FuneralRock { get; set; } = string.Empty;
        public string StelaSize { get; set; } = string.Empty;
        public string StelaSection { get; set; } = string.Empty;
        public string StandSize { get; set; } = string.Empty;
        public string StandSection { get; set; } = string.Empty;
        public string FlowerSize { get; set; } = string.Empty;
        public string FlowerSection { get; set; } = string.Empty;
        public string FlowerIndicate { get; set; } = "False";
        public string PolishingColor { get; set; } = string.Empty;
        public string InstalPrice { get; set; } = string.Empty;
        public string InstalIndicate { get; set; } = "False";
        #endregion

        #region Data
        public ObservableCollection<string> Some { get; set; } = new();
        public ObservableCollection<string> FuneralsCategory { get; set; } = new()
        {
            "Вертикаль", "Горизонталь", "Детям", "Кресты", "Мусульманские", "3D модели"
        };
        public ObservableCollection<string> RockType { get; set; } = new()
        {
            "Габбро-диабаз","Мансурвский","Дымовский","Венге","Желтак","Кордайский","Балтик грин",
        };
        public ObservableCollection<string> StelaWidth { get; set; } = new()
        {
            "100x50","110x50","155*50","120x60","120x70","120x80","120x90","130x65","130x70","140x70","140x80","другое"
        };
        public ObservableCollection<string> StelasSection { get; set; } = new()
        {
            "6","7","8","9","10"
        };
        public ObservableCollection<string> StandWidth { get; set; } = new()
        {
            "55","60","70","80","90","100","110", "120", "130", "140"
        };
        public ObservableCollection<string> StandsSection { get; set; } = new()
        { "15x20", "15x20", "20x20", "другое"};
        public ObservableCollection<string> FloralWidth { get; set; } = new()
        { "100x60x8x5", "120x70x8x5", "другое" };
        public ObservableCollection<string> FloralSection { get; set; } = new()
        { ""};
        public ObservableCollection<string> PolishingColors { get; set; } = new()
        {
            "2x","3x","4x","5x"
        };
        public ObservableCollection<string> FuneralType { get; set; } = new()
        {
            "Литьевой", "Гранитный", "Мраморный"
        };


        private string _response;
        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
                Clean();
                OnPropertyChanged();
                _orderPage.FormingButton.IsEnabled = false;
            }
        }
        #endregion

        public ICommand AddOrder => new AddOrderCommand(this);
        public ICommand AddServices => new AddServicesCommand(this);
        public ICommand AddComplect => new AddOrderComplectCommand(this);
        public ICommand AddDeads => new AddDeadsCommand(this);
        public ICommand DeleteLastDead => new DeleteLastDeadCommand(this);


        private string ErrorInput(string value)
        {
            string dateString = value.Replace(".", "/");
            try
            {
                string format = "dd/MM/yyyy";
                DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
                dateString = value.Replace("/", ".");
            }
            catch
            {
                MessageBox.Show("Дата изготовления введена неверно");
                return "";
            }
            return dateString;
        }

        private void OneTimeNotFagot()
        {
            FuneralCategory = "1";
            FuneralModel = "2";
            FuneralRock = "3";
            StelaSize = "4";
            StelaSection = "5";
            StandSize = "6";
            StandSection = "7";
            FlowerSize = "8";
            FlowerSection = "9";
            FlowerIndicate = "False";
            PolishingColor = "10";
            InstalPrice = "11";
            InstalIndicate = "False";

            ClientName = "12";
            ClientLastName = "13";
            ClientThirdName = "14";
            ClientAdress = "15";
            ClientNumber = "16";
            ClientFuneral = "17";
            ClientSocial = "18";
            ClientPassport = "19";
            ClientDelivery = "20";
            CreateFuneralDate = "12.12.2021";

            FuneralSize = "22";
            UpDesign = "23";
            DownDesign = "24";
            OtherDesign = "25";
            Epitafia = "26";
            Color = "27";

            BirthDeads = "12.02.2021";
            DeathDeads = "12.01.2021";
            Name = "her";
            LastName = "Name";
            ThirdName = "her";
        }

        private void Clean()
        {
            FuneralCategory = "";
            FuneralModel = "";
            FuneralRock = "";
            StelaSize = "";
            StelaSection = "";
            StandSize = "";
            StandSection = "";
            FlowerSize = "";
            FlowerSection = "";
            FlowerIndicate = "False";
            PolishingColor = "";
            InstalPrice = "";
            InstalIndicate = "False";

            ClientName = "";
            ClientLastName = "";
            ClientThirdName = "";
            ClientAdress = "";
            ClientNumber = "";
            ClientFuneral = "";
            ClientSocial = "";
            ClientPassport = "";
            ClientDelivery = "";

            FuneralSize = "";
            UpDesign = "";
            DownDesign = "";
            OtherDesign = "";
            Epitafia = "";
            Color = "";

            BirthDeads = "";
            DeathDeads = "";
            Name = "";
            LastName = "";
            ThirdName = "";
        }
    }
}

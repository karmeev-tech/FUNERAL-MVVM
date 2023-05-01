using Domain.Complect;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Services;
using FUNERALMVVM.View.Windows;
using Infrastructure.Complect;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class ServicesController : ViewModelBase
    {
        private OrdersWindow _ordersWindow;

        #region хуйня
        private string _cokolCount = "1";
        private string _bordCount = "1";
        private string _plitkaCount = "1";
        private string _paroizolCount = "1";
        private string _sandCount = "1";
        private string _gruntCount = "1";
        private string _granitCount = "1";
        private string _s1 = string.Empty;
        private string _s4 = string.Empty;
        private string _s5 = string.Empty;
        private string _s10 = string.Empty;
        private string _s11 = string.Empty;
        private string _s12 = string.Empty;
        private string _s15 = string.Empty;
        private string _exception = string.Empty;

        #endregion

        private readonly ComplectRepos _complectRepos = new();
        private readonly List<ItemComplectEntity> _listComplect;
        public ServicesController(OrdersWindow ordersWindow)
        {
            _ordersWindow = ordersWindow;
            _listComplect = _complectRepos.GetItems();
            s1 = _listComplect[5].Money.ToString();
            s4 = _listComplect[6].Money.ToString();
            s5 = _listComplect[7].Money.ToString();
            s10 = _listComplect[8].Money.ToString();
            s11 = _listComplect[9].Money.ToString();
            s12 = _listComplect[10].Money.ToString();
            s15 = _listComplect[11].Money.ToString();
            //подтягиваем material
        }

        public string s1
        {
            get => _s1; set
            {
                _s1 = value;
                OnPropertyChanged(nameof(s1));
            }
        }
        public string s2 { get; set; } = "0";
        public string s4
        {
            get => _s4; set
            {
                _s4 = value;
                OnPropertyChanged(nameof(s4));
            }
        }
        public string s5
        {
            get => _s5; set
            {
                _s5 = value;
                OnPropertyChanged(nameof(s5));
            }
        }
        public string s6 { get; set; } = "0";
        public string s7 { get; set; } = "0";
        public string s8 { get; set; } = "0";
        public string s9 { get; set; } = "0";
        public string s10
        {
            get => _s10; set
            {
                _s10 = value;
                OnPropertyChanged(nameof(s10));
            }
        }
        public string s11
        {
            get => _s11; set
            {
                _s11 = value;
                OnPropertyChanged(nameof(s11));
            }
        }
        public string s12
        {
            get => _s12; set
            {
                _s12 = value;
                OnPropertyChanged(nameof(s12));
            }
        }
        public string s15
        {
            get => _s15; set
            {
                _s15 = value;
                OnPropertyChanged(nameof(s15));
            }
        }
        public string s16 { get; set; } = "0";
        public string s17 { get; set; } = "0";
        public string Bord { get; set; } = string.Empty;
        public string Plitka { get; set; } = string.Empty;
        public string PlitkaOther { get; set; } = "другое";
        public string Funeral { get; set; } = string.Empty;
        public string Fences { get; set; } = string.Empty;
        public string Tables { get; set; } = string.Empty;

        /// <summary>
        /// тута количество
        /// </summary>
        /// 

        public string CokolCount
        {
            get => _cokolCount;
            set
            {
                _cokolCount = value;
                s1 = (Convert.ToInt32(s1) * Convert.ToInt32(CokolCount)).ToString();
            }
        }
        public string BordCount
        {
            get => _bordCount;
            set
            {
                _bordCount = value;
                s4 = (Convert.ToInt32(s4) * Convert.ToInt32(BordCount)).ToString();
            }
        }
        public string PlitkaCount
        {
            get => _plitkaCount; set
            {
                _plitkaCount = value;
                s5 = (Convert.ToInt32(s5) * Convert.ToInt32(PlitkaCount)).ToString();
            }
        }
        public string ParoizolCount
        {
            get => _paroizolCount; set
            {
                _paroizolCount = value;
                s10 = (Convert.ToInt32(s10) * Convert.ToInt32(ParoizolCount)).ToString();
            }
        }
        public string SandCount
        {
            get => _sandCount; set
            {
                _sandCount = value;
                s11 = (Convert.ToInt32(s11) * Convert.ToInt32(SandCount)).ToString();
            }
        }
        public string GruntCount
        {
            get => _gruntCount; set
            {
                _gruntCount = value;
                s12 = (Convert.ToInt32(s12) * Convert.ToInt32(GruntCount)).ToString();
            }
        }
        public string GranitCount
        {
            get => _granitCount; set
            {
                _granitCount = value;
                s15 = (Convert.ToInt32(s15) * Convert.ToInt32(GranitCount)).ToString();
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

        private void ViewClosed()
        {
            _ordersWindow.Opacity = 0;
            _ordersWindow.Close();
        }
    }
}

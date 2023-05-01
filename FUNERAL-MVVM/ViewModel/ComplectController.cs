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
    public class ComplectController : ViewModelBase
    {
        private KomplektWindow _komplektWindow;
        private readonly ComplectRepos _complectRepos = new();
        private readonly List<ItemComplectEntity> _listComplect;
        public ComplectController(KomplektWindow komplektWindow)
        {
            _komplektWindow = komplektWindow;
            _listComplect = _complectRepos.GetItems();
            //поправь и сделай выборку
            s9 = _listComplect[0].Money.ToString();
            s10 = _listComplect[1].Money.ToString();
            s11 = _listComplect[2].Money.ToString();
            s13 = _listComplect[3].Money.ToString();
            s14 = _listComplect[4].Money.ToString();
        }

        private string _response = string.Empty;
        private string _s9;
        private string _s10;
        private string _s11;
        private string _s13;
        private string _s14;
        private string _gazonSize = "1";
        private string _mramorCount = "1";
        private string _flowersCount = "1";
        private string _krestickCount = "1";
        private string _metrickCount = "1";

        public string s1 { get; set; } = "0";
        public string s2 { get; set; } = "0";
        public string s3 { get; set; } = "0";
        public string s4 { get; set; } = "0";
        public string s5 { get; set; } = "0";
        public string s6 { get; set; } = "0";
        public string s7 { get; set; } = "0";
        public string s8 { get; set; } = "0";
        public string s9
        {
            get => _s9;
            set
            {
                _s9 = value;
                OnPropertyChanged(nameof(s9));
            }
        }
        public string s10
        {
            get => _s10;
            set
            {
                _s10 = value;
                OnPropertyChanged(nameof(s10));
            }
        }
        public string s11
        {
            get => _s11;
            set
            {
                _s11 = value;
                OnPropertyChanged(nameof(s11));
            }
        }
        public string s12 { get; set; } = "0";
        public string s13
        {
            get => _s13;
            set
            {
                _s13 = value;
                OnPropertyChanged(nameof(s13));
            }
        }
        public string s14
        {
            get => _s14;
            set
            {
                _s14 = value;
                OnPropertyChanged(nameof(s14));
            }
        }
        public string StelaSize { get; set; } = string.Empty;
        public string StelaSection { get; set; } = string.Empty;
        public string StandSize { get; set; } = string.Empty;
        public string StandSection { get; set; } = string.Empty;
        public string FloralSize { get; set; } = string.Empty;
        public string FloralSection { get; set; } = string.Empty;
        public string FloralSectionOptional { get; set; } = string.Empty;
        public string Polishing { get; set; } = string.Empty;
        public string Portrait { get; set; } = string.Empty;
        public string LetterColor { get; set; } = string.Empty;
        public string GazonSize
        {
            get => _gazonSize;
            set
            {
                _gazonSize = value;
                s13 = (Convert.ToInt32(s13) * Convert.ToInt32(GazonSize)).ToString();
            }
        }
        public string MramorCount
        {
            get => _mramorCount;
            set
            {
                _mramorCount = value;
                s14 = (Convert.ToInt32(s14) * Convert.ToInt32(MramorCount)).ToString();
            }
        }
        public string DeliverTo { get; set; } = string.Empty;

        public string FlowersCount
        {
            get => _flowersCount;
            set
            {
                _flowersCount = value;
                s9 = (Convert.ToInt32(s9) * Convert.ToInt32(FlowersCount)).ToString();
            }
        }

        public string MetrickCount
        {
            get => _metrickCount;
            set
            {
                _metrickCount = value;
                s11 = (Convert.ToInt32(s11) * Convert.ToInt32(MetrickCount)).ToString();
            }
        }
        public string KrestickCount
        {
            get => _krestickCount;
            set
            {
                _krestickCount = value;
                s10 = (Convert.ToInt32(s10) * Convert.ToInt32(KrestickCount)).ToString();
            }
        }
        public ICommand AddComplectCommand => new AddComplectCommand(this);

        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                if (Response != "Ошибка")
                {
                    ViewClosed();
                }

                OnPropertyChanged(Response);
            }
        }

        private void ViewClosed()
        {
            _komplektWindow.Opacity = 0;
            _komplektWindow.Close();
        }
    }
}

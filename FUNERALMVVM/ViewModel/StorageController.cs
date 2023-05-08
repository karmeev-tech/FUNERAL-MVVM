using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Storage;
using System;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class StorageController : ViewModelBase
    {
        private string _error = string.Empty;

        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        private string _price = string.Empty;
        public string Price 
        {
            get
            {
                return _price;
            }
            set
            { 
                _price = value;
                if(_price != string.Empty && _zakup != string.Empty) 
                {
                    Margin = (Convert.ToInt32(_price) - Convert.ToInt32(_zakup)).ToString();
                    OnPropertyChanged(nameof(Margin));
                }
            }
        }
        public string Error { get => _error; set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            } 
        }

        private string _zakup = string.Empty;
        public string ZakupPrice 
        { 
            get => _zakup;
            set
            { 
                _zakup = value;

            } 
        }

        public string OForm { get; set; } = string.Empty;
        public string TForm { get; set; } = string.Empty;
        public string GForm { get; set; } = string.Empty;
        public string Margin { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Polishing { get; set; } = string.Empty;
        public string Other { get; set; } = string.Empty;

        public ICommand AddItem => new AddItemCommand(this);
    }
}

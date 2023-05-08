using Domain.Complect;
using FUNERAL_MVVM.Utility;
using FuneralClient.Commands.Complect;
using FUNERALMVVM.View.Windows;
using LegacyInfrastructure.Complect;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class ComplectController : ViewModelBase
    {
        private KomplektWindow _komplektWindow;
        private readonly ComplectRepos _complectRepos = new();
        private ObservableCollection<string> _itemFromComplect = new();
        public List<ItemComplectEntity> ComplectStorage { get; set; }

        public ObservableCollection<string> ItemFromComplect 
        { 
            get => _itemFromComplect;
            set
            {
                _itemFromComplect = value;
                OnPropertyChanged(nameof(ItemFromComplect));
            } 
        }

        private ObservableCollection<ItemComplectEntity> _items = new();
        public ObservableCollection<ItemComplectEntity> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public string SelectItem { get; set; }

        public ComplectController(KomplektWindow complectWindow)
        {
            _komplektWindow = complectWindow;

            var items = _complectRepos.GetItems();
            ComplectStorage = items;

            foreach (var item in items)
            {
                _itemFromComplect.Add(item.Name);
            }

        }

        public ICommand AddComplectCommand => new AddComplectCommand(this);
        public ICommand AddItemCommand => new AddItemCommand(this);

        private string _response = string.Empty;
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

        public void DeleteItem(string itemName)
        {
            var newItems = Items.Where(x => x.Name == itemName).ToList();
            foreach (var item in newItems)
            {
                Items.Remove(item);
            }
        }
    }
}

using Domain.Complect;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Shop;
using FUNERALMVVM.View.Windows;
using Shop;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class SellItemController : ViewModelBase
    {
        public SellItemController()
        {
            var items = new ShopProvider().GetItems();
            ComplectStorage = items;

            foreach (var item in items)
            {
                _itemFromComplect.Add(item.Name);
            }
        }
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

        public List<ItemComplectEntity> ItemsPack { get; set; } = new();

        public string SelectItem { get; set; }

        public ICommand AddItemCommand => new AddShopItemCommand(this);
        public ICommand SellCommand => new AddSellCommand(this);

        private string _response = string.Empty;

        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(Response);
            }
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

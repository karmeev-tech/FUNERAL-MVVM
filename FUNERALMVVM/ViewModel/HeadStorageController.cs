using Domain.Shop;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.HeadStorage;
using Shop;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class HeadStorageController : ViewModelBase
    {
        private ObservableCollection<ShoppingItem> _items = new();
        public HeadStorageController()
        {
            ShopProvider shopProvider = new();
            var shopItems = shopProvider.GetAllItems();
            foreach (var item in shopItems)
            {
                Items.Add(item);
            }
        }

        public ObservableCollection<ShoppingItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public ICommand UpdateBase => new HeadStorageCommand(this);
    }
}

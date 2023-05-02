using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.HeadStorage;
using LegacyInfrastructure.Storage;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class HeadStorageController : ViewModelBase
    {
        private ObservableCollection<ShopItem> _items = new();
        private readonly IShopRepos _shopRepos = new ShopRepos();
        public HeadStorageController()
        {
            Items = _shopRepos.GetItems();
        }

        public ObservableCollection<ShopItem> Items
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

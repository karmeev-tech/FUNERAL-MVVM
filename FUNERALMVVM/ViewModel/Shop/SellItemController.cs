using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Shop;
using Infrastructure.Model.Storage;
using LegacyInfrastructure.Worker;
using Shop.EF;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Worker.EF;

namespace FUNERALMVVM.ViewModel
{
    public class SellItemController : ViewModelBase
    {
        public SellItemController()
        {
            WorkerRepos repos = new WorkerRepos();
            string userLog = repos.GetLastFromJournal();

            string shopname = WorkerConnector.GetWorkerShop(userLog);
            _shopName = shopname;
            var items = ShopConnector.GetStorageItems(shopname);
            ComplectStorage = items;

            foreach (var item in items)
            {
                _itemFromComplect.Add(item.Name);
            }
        }

        public string _shopName = "";

        private ObservableCollection<string> _itemFromComplect = new();
        public List<StorageItemEntity> ComplectStorage { get; set; }

        public ObservableCollection<string> ItemFromComplect
        {
            get => _itemFromComplect;
            set
            {
                _itemFromComplect = value;
                OnPropertyChanged(nameof(ItemFromComplect));
            }
        }

        private ObservableCollection<StorageItemEntity> _items = new();

        public ObservableCollection<StorageItemEntity> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public List<StorageItemEntity> ItemsPack { get; set; } = new();

        public string SelectItem { get; set; }

        public ICommand AddItemCommand => new AddShopItemCommand(this);
        public ICommand SellCommand => new AddSellCommand(this);

        private string _response = "";

        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
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

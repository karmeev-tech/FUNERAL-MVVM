using BossInstruments;
using DocumentFormat.OpenXml.Spreadsheet;
using FUNERAL_MVVM.Utility;
using FuneralClient.Commands.Complect;
using Infrastructure.Model.Storage;
using LegacyInfrastructure.Storage;
using Shop.EF;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel.Shop
{
    public class OrderRequestVM : ViewModelBase
    {
        private ObservableCollection<StorageItemEntity> _items = new();
        private ObservableCollection<string> _storageEntities;
        private ObservableCollection<string> _storageItemEntities;

        public void DeleteItem(string itemName)
        {
            var newItems = Items.Where(x => x.Name == itemName).ToList();
            foreach (var item in newItems)
            {
                Items.Remove(item);
            }
        }

        public string _shopName = string.Empty;
        private string _response;

        public OrderRequestVM()
        {
            ShopConnector shopConnector = new ShopConnector();
            StorageEntities = new ObservableCollection<string>(ShopConnector.GetShops());
            //StorageItemEntities = new ObservableCollection<string>(ShopConnector.GetStorageItems())
        }

        public string ShopName
        {
            get
            {
                return _shopName;
            }
            set
            {
                _shopName = value;
                OnPropertyChanged(nameof(ShopName));

                StorageItemEntities = new ObservableCollection<string>(ShopConnector.GetStorageItems(value).Select(x => x.Name));
            }
        }

        public string ItemName
        {
            get;set;
        }

        public string Response
        {
            get => _response; set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
            }
        }

        #region EF
        public ObservableCollection<string> StorageEntities
        {
            get => _storageEntities;
            set
            {
                _storageEntities = value;
                OnPropertyChanged(nameof(StorageEntities));
            }
        }
        public ObservableCollection<string> StorageItemEntities
        {
            get => _storageItemEntities;
            set
            {
                _storageItemEntities = value;
                OnPropertyChanged(nameof(StorageItemEntities));
            }
        }

        public ObservableCollection<StorageItemEntity> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        #endregion

        public ICommand AddItem => new AddItemCommand(this);
        public ICommand SendInvent => new SendRequest(this);
    }

    public class AddItemCommand : BaseCommands
    {
        private OrderRequestVM _orderRequestVM;

        public AddItemCommand(OrderRequestVM orderRequestVM)
        {
            _orderRequestVM = orderRequestVM;
        }

        public override void Execute(object parameter)
        {
            _orderRequestVM.Items.Add
                (
                ShopConnector.GetStorageItems(_orderRequestVM.ShopName).Where(x => x.Name == _orderRequestVM.ItemName).First()
                );
        }
    }

    public class SendRequest : BaseCommands
    {
        private OrderRequestVM _orderRequestVM;

        public SendRequest(OrderRequestVM orderRequestVM)
        {
            _orderRequestVM = orderRequestVM;
        }

        public override void Execute(object parameter)
        {
            var items = _orderRequestVM.Items.ToList();
            foreach (var item in items)
            {
                item.ShopName = ShopConnector.GetShop(_orderRequestVM.ShopName);
            }
            BossProvider.SendInvent(items);
        }
    }
}

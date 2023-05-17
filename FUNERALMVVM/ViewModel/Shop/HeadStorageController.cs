using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.HeadStorage;
using FUNERALMVVM.View.Windows;
using Infrastructure.Model.Storage;
using Shop.EF;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class HeadStorageController : ViewModelBase
    {
        private ObservableCollection<StorageItemEntity> _items = new();
        private ObservableCollection<string> _storageEntities;

        public HeadStorageController()
        {
            ShopConnector shopConnector = new ShopConnector();
            StorageEntities = new ObservableCollection<string>(ShopConnector.GetShops());
        }
        public ICommand UpdateBase => new HeadStorageCommand(this);
        public ICommand AddItem => new AddItemsStorageCommand(this);
        public ICommand AddShop => new AddShopCommand(this);
        public ICommand DeleteShop => new DeleteShopCommand(this);
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

                ShopConnector shopConnector = new();
                List<StorageItemEntity> items = ShopConnector.GetStorageItems(ShopName);

                Items = new(items);
            }
        }

        public string Response { get => _response; set
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

        public void UpdateStorages()
        {
            ShopConnector shopConnector = new ShopConnector();
            StorageEntities = new ObservableCollection<string>(ShopConnector.GetShops());
        }
    }

    public class AddItemsStorageCommand : BaseCommands
    {
        private readonly HeadStorageController _controller;

        public AddItemsStorageCommand(HeadStorageController controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
           _controller.Items.Add(new StorageItemEntity());
        }
    }

    public class AddShopCommand : BaseCommands
    {
        private HeadStorageController _headStorageController;

        public AddShopCommand(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
        }

        public override void Execute(object parameter)
        {
            NewShopWindow newShopWindow = new NewShopWindow(_headStorageController);
            newShopWindow.Show();
        }
    }

    public class DeleteShopCommand : BaseCommands
    {
        private HeadStorageController _headStorageController;

        public DeleteShopCommand(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
        }

        public override void Execute(object parameter)
        {
            DeleteShopWindow deleteShopWindow = new(_headStorageController);
            deleteShopWindow.Show();
        }
    }
}

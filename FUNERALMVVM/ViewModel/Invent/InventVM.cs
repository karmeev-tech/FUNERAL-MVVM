using BossInstruments;
using ClassLibrary;
using FUNERAL_MVVM.Utility;
using Infrastructure.Model.Storage;
using Shop.EF;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel.Invent
{
    public class InventVM : ViewModelBase
    {
        private ObservableCollection<StorageItemEntity> _items;

        public ObservableCollection<StorageItemEntity> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
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

        public ICommand Upload => new UploadCommand(this);
        public ICommand Update => new UpdateUserStorage(this);
    }

    public class UploadCommand : BaseCommands
    {
        private InventVM _vm;

        public UploadCommand(InventVM vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            PickManager pickManager = new PickManager();
            var path = pickManager.OpenManagerFileNameJson();
            var result = BossProvider.GetInvent(path);
            _vm.Items = new ObservableCollection<StorageItemEntity>(result);
        }
    }

    public class UpdateUserStorage : BaseCommands
    {
        private InventVM _vm;

        public UpdateUserStorage(InventVM vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            var items = _vm.Items.ToList();
            var shopName = items.Select(x => x.ShopName.Name).First();
            ShopConnector.InventUpdate(items, shopName);
        }
    }
}

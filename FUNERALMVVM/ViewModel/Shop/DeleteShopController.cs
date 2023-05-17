using FUNERAL_MVVM.Utility;
using Shop.EF;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel.Shop
{
    public class DeleteShopController : ViewModelBase
    {
        private HeadStorageController _headStorageController;

        private string _response;
        private ObservableCollection<string> _shops;
        private string _selectedNameShop;

        public DeleteShopController(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
            ShopConnector shopConnector = new();
            Shops = new(ShopConnector.GetShops());
        }

        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
                _headStorageController.UpdateStorages();
            }
        }
        public string SelectedNameShop { get => _selectedNameShop;
            set 
            {
                _selectedNameShop = value;
                OnPropertyChanged(nameof(SelectedNameShop));
            }
        }

        public ObservableCollection<string> Shops
        {
            get => _shops;
            set
            {
                _shops = value;
                OnPropertyChanged(nameof(Shops));
            }
        }

        public ICommand DeleteBaseShop => new DeleteBaseShop(this);
    }

    public class DeleteBaseShop : BaseCommands
    {
        private readonly DeleteShopController _deleteShopController;

        public DeleteBaseShop(DeleteShopController deleteShopController)
        {
            _deleteShopController = deleteShopController;
        }

        public override void Execute(object parameter)
        {
            ShopConnector shopConnector = new();
            _deleteShopController.Response = shopConnector.DeleteShop(_deleteShopController.SelectedNameShop);
        }
    }
}

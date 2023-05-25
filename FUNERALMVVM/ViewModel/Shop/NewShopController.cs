using FUNERAL_MVVM.Utility;
using Shop.EF;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class NewShopController : ViewModelBase
    {
        private HeadStorageController _headStorageController;

        public NewShopController(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
        }

        private string _response;

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
        public string NameShop { get; set; }
        public ICommand AddBaseShop => new AddBaseShop(this);
    }

    public class AddBaseShop : BaseCommands
    {
        private readonly NewShopController _newShopController;

        public AddBaseShop(NewShopController newShopController)
        {
            _newShopController = newShopController;
        }

        public override void Execute(object parameter)
        {
            ShopConnector shopConnector = new();
            _newShopController.Response = shopConnector.AddShop(_newShopController.NameShop);
        }
    }
}

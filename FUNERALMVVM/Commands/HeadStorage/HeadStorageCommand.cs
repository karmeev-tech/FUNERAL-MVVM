using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Shop.EF;
using System.Linq;

namespace FUNERALMVVM.Commands.HeadStorage
{
    public class HeadStorageCommand : BaseCommands
    {
        private readonly HeadStorageController _headStorageController;
        public HeadStorageCommand(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
        }

        public override void Execute(object parameter)
        {
            var items = _headStorageController.Items.ToList();
            ShopConnector shopConnector = new();
            if (_headStorageController.ShopName == string.Empty)
            {
                _headStorageController.Response = "Выберите имя магазина";
                return;
            }
            shopConnector.UpdateDB(items,_headStorageController.ShopName);
        }
    }
}

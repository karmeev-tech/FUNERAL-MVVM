using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Shop;

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
            var items = _headStorageController.Items;
            ShopProvider shopProvider = new();
            foreach (var item in items) 
            {
                shopProvider.UpdateItems(item);
            }

            _headStorageController.Items = new();
            var resultItems = shopProvider.GetAllItems();
            foreach (var item in resultItems)
            {
                _headStorageController.Items.Add(item);
            }
        }
    }
}

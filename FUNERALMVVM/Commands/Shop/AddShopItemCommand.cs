using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.Storage;
using System.Linq;

namespace FUNERALMVVM.Commands.Shop
{
    public class AddShopItemCommand : BaseCommands
    {
        private readonly SellItemController _complectController;

        public AddShopItemCommand(SellItemController complectController)
        {
            _complectController = complectController;
        }

        public override void Execute(object parameter)
        {
            var entity = _complectController.ComplectStorage
            .Where(x => x.Name == _complectController.SelectItem);
            StorageItemEntity itemComplectEntity = new()
            {
                Name = _complectController.SelectItem,
                Price = entity.ToList()[0].Price,
                Count = entity.ToList()[0].Count,
                Procent = entity.ToList()[0].Procent
            };

            var duplicate = _complectController.Items.Where(x => x.Name == itemComplectEntity.Name);
            if (duplicate.Any())
            {
                return;
            }

            _complectController.Items.Add(itemComplectEntity);
            _complectController.ItemsPack.Add(itemComplectEntity);
        }
    }
}

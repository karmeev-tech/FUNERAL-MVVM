using Domain.Complect;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
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
            ItemComplectEntity itemComplectEntity = new()
            {
                Name = _complectController.SelectItem,
                Money = entity.ToList()[0].Money,
                Count = entity.ToList()[0].Count,
                Procent = entity.ToList()[0].Procent
            };
            _complectController.Items.Add(itemComplectEntity);
            _complectController.ItemsPack.Add(itemComplectEntity);
        }
    }
}

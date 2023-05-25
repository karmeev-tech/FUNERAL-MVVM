using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.Storage;
using System.Linq;

namespace FuneralClient.Commands.Complect
{
    public class AddItemCommand : BaseCommands
    {
        private readonly ComplectController _complectController;

        public AddItemCommand(ComplectController complectController)
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
                Procent = entity.ToList()[0].Procent,
            };
            _complectController.Items.Add(itemComplectEntity);
        }
    }
}

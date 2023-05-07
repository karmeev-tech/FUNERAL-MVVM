using Domain.Complect;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
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
            ItemComplectEntity itemComplectEntity = new()
            {
                Name = _complectController.SelectItem,
                Money = entity.ToList()[0].Money,
                Count = entity.ToList()[0].Count,
            };
            _complectController.Items.Add(itemComplectEntity);
        }
    }
}

using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System.Linq;

namespace FUNERALMVVM.Commands.Orders
{
    public class DeleteLastDeadCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public DeleteLastDeadCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            if (_orderController._deadboydCount > 0)
            {
                _orderController.Deadbody = "";
                _orderController._deadsCollection.Remove(_orderController._deadsCollection.Last());
                foreach (var item in _orderController._deadsCollection)
                {
                    _orderController.Deadbody += item;
                }
                _orderController._deadboydCount--;
            }
        }
    }
}

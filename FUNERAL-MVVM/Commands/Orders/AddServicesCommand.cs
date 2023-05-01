using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View.Windows;
using FUNERALMVVM.ViewModel;

namespace FUNERALMVVM.Commands.Orders
{
    public class AddServicesCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public AddServicesCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            OrdersWindow window = new();
            window.Show();
        }
    }
}

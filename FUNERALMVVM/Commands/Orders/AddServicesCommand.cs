using FUNERAL_MVVM.Utility;
using FuneralClient.View.Windows;
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
            ServicesWindow window = new();
            window.Show();
        }
    }
}

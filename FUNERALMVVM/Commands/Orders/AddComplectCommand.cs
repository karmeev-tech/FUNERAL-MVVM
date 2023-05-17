using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View.Pages;
using FUNERALMVVM.View.Windows;
using FUNERALMVVM.ViewModel;

namespace FUNERALMVVM.Commands.Orders
{
    public class AddOrderComplectCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public AddOrderComplectCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            KomplektWindow window = new(_orderController._orderPage);
            window.Show();
        }
    }
}

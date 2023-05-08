using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;

namespace FUNERALMVVM.Commands.Orders
{
    public class AddDeadsCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public AddDeadsCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            if (_orderController.BirthDeads == null || _orderController.FIOdeads == null || _orderController.DeathDeads == null)
                return;
            if (ErrorInput(_orderController.BirthDeads, _orderController.FIOdeads, _orderController.DeathDeads) != 3)
                return;

            if (_orderController._deadboydCount < 4)
            {
                _orderController._deadboydCount++;
                _orderController.Deadbody += _orderController.FIOdeads + " " + _orderController.BirthDeads + " " + _orderController.DeathDeads + "\n";
                _orderController._deadsCollection.Add(_orderController.FIOdeads + " " + _orderController.BirthDeads + " " + _orderController.DeathDeads + "\n");
                _orderController.BirthDeads = string.Empty;
                _orderController.FIOdeads = string.Empty;
                _orderController.DeathDeads = string.Empty;
            }
            else
            {
                _orderController.BirthDeads = string.Empty;
                _orderController.FIOdeads = string.Empty;
                _orderController.DeathDeads = string.Empty;
            }
        }

        private int ErrorInput(string birth, string fio, string death)
        {
            int counter = 0;
            if (birth.Replace(" ", "") != "" && birth.Length == 10)
                counter++;
            if (death.Replace(" ","") != "" && death.Length == 10)
                counter++;
            if (fio.Replace(" ", "") != "")
                counter++;
            return counter;
        }
    }
}

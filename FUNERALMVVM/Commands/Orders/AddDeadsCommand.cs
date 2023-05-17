using DocumentFormat.OpenXml.Wordprocessing;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Model.Order;
using FUNERALMVVM.ViewModel;
using System;
using System.Globalization;
using System.Windows;

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
            if (ErrorInput(_orderController.BirthDeads, _orderController.DeathDeads) != 2)
                return;
            var birth = _orderController.BirthDeads;
            if (birth.Contains("/"))
            {
                birth = birth.Replace("/", ".");
            }
            var dead = _orderController.DeathDeads;
            if (dead.Contains("/"))
            {
                dead = dead.Replace("/", ".");
            }

            DeadModel deadModel = new() 
            { 
                Name = _orderController.Name,
                LastName = _orderController.LastName,
                ThirdName = _orderController.ThirdName,
                Life = birth,
                Death = dead,
            };

            _orderController.Name = string.Empty;
            _orderController.LastName = string.Empty;
            _orderController.ThirdName = string.Empty;
            _orderController.BirthDeads = string.Empty;
            _orderController.DeathDeads = string.Empty;

            if (_orderController._deadboydCount < 4)
            {
                _orderController._deadboydCount++;
                _orderController.Deadbody += deadModel.GetDead() + "\n";
                _orderController._deadsCollection.Add(deadModel.GetDead() + "\n");
                _orderController._deadModels.Add(deadModel);
            }
        }

        private static int ErrorInput(string birth, string death)
        {
            try
            {
                string dateString = birth.Replace(".","/");
                string format = "dd/MM/yyyy";
                DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
                dateString = death.Replace(".", "/");
                dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Дата введена неверно");
                return -1;
            }
            return 2;
        }
    }
}

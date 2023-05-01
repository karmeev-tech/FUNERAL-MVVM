using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System.IO;
using System.Text.Json;
using System;

namespace FUNERALMVVM.Commands.Orders
{
    public class GetComplectCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public GetComplectCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            string json = "";
            using (StreamReader r = new StreamReader(".docs\\ServFuneralDoc.json"))
            {
                json = r.ReadToEnd();
            }

            string sech;

            ComplectList deServ =
                JsonSerializer.Deserialize<ComplectList>(json);

            _orderController.Complect =
                deServ.Stela + deServ.Podstavka + deServ.Cvetnik + deServ.Polish +
                deServ.Gravity + deServ.Ograda + deServ.Lavka + deServ.Vaza +
                deServ.Flowers + deServ.Krestick + deServ.Metrick + deServ.Coloring +
                deServ.Gazon + deServ.Mramor;

            // всякие условности
            if (deServ.DeliverTo != string.Empty)
            {
                _orderController.Complect += deServ.DeliverTo + " \n";
            }

            var price = Convert.ToInt64(_orderController.Price);

            _orderController.FuneralPrice += deServ.Money;

            price += deServ.Money;

            _orderController.Price = price.ToString();
        }
    }
}

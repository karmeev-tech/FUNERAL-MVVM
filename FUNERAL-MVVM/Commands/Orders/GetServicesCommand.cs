using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System;
using System.IO;
using System.Text.Json;

namespace FUNERALMVVM.Commands.Orders
{
    public class GetServicesCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public GetServicesCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            string json = "";
            using (StreamReader r = new StreamReader(".docs\\ServDoc.json"))
            {
                json = r.ReadToEnd();
            }

            ServiceList deServ =
                JsonSerializer.Deserialize<ServiceList>(json);

            _orderController.AllServices =
                deServ.Cokol + deServ.Found + deServ.Bord + deServ.Plitka +
                deServ.Funeral + deServ.Ograda + deServ.Lavochka + deServ.Svarka +
                deServ.Paroizol + deServ.Sand + deServ.Grunt + deServ.Granit +
                deServ.Oformlenie + deServ.Stolb;

            var price = Convert.ToInt64(_orderController.Price);
            price += deServ.Money;
            _orderController.Price = price.ToString();
        }
    }
}

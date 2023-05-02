using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Order;
using LegacyInfrastructure.Storage;
using System;
using System.Threading.Tasks;

namespace FUNERALMVVM.Commands.Orders
{
    public class AddOrderCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public AddOrderCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            DateTime dateTime = DateTime.Now;
            AddDocument();
        }
        public async void AddDocument()
        {
            ShopItem item = new ShopRepos().GetItemByName(_orderController.Funeral);
            await Task.Run(() =>
            {
                OrderManager manager = new();

                manager.CreateDoc("1",
                    _orderController.ClientFIO,
                    _orderController.ClientPassport,
                    _orderController.ClientAdress,
                    _orderController.AllServices,
                    Convert.ToString(_orderController.ServsPrice),
                    Convert.ToString(_orderController.FuneralPrice),
                    _orderController.Prepayment,
                    _orderController.ClientNumber);

                manager.CreateFuneralDock("1",
                    _orderController.ClientFIO,
                    _orderController.ClientPassport,
                    _orderController.ClientAdress,
                    _orderController.Complect,
                    _orderController.Price,
                    _orderController.Prepayment,
                    _orderController.ClientNumber,
                    _orderController.ClientFuneral);

                manager.CreateBlank(
                    _orderController._deadEntities.Count,
                    _orderController.ClientFIO,
                    "adress",
                    _orderController.Complect,
                    _orderController.Price,
                    _orderController.Prepayment,
                    _orderController.ClientNumber,
                    "",
                    "",
                    DateTime.Now.ToString(),
                    item.OForm,
                    item.TForm,
                    item.GForm,
                    item.Color,
                    item.Polishing,
                    item.Other,
                    _orderController.UpDesign,
                    _orderController.DownDesign,
                    _orderController.OtherDesign,
                    "",
                    _orderController._deadEntities);
            });
        }
    }
}

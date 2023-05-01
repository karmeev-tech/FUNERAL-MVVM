using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Storage;
using System;

namespace FUNERALMVVM.Commands.Orders
{
    public class UpdateFuneralsCommand : BaseCommands
    {
        private readonly OrderController _orderController;
        private readonly IShopRepos _shopRepos = new ShopRepos();
        public UpdateFuneralsCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            var items = _shopRepos.GetItems();
            int price = 0;
            foreach (var item in items)
            {
                if(_orderController.Funeral == item.Name)
                {
                    price = item.Price;
                    _orderController.FuneralPrice = item.Price;
                }
            }
            price += Convert.ToInt32(_orderController.Price);
            _orderController.Price = Convert.ToString(price);
        }
    }
}

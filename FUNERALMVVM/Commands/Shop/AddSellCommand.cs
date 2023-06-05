using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Mongo;
using Shop.EF;
using System;
using System.IO;
using Worker.EF;

namespace FUNERALMVVM.Commands.Shop
{
    public class AddSellCommand : BaseCommands
    {
        private readonly SellItemController _sellController;

        public AddSellCommand(SellItemController sellController)
        {
            _sellController = sellController;
        }

        public override void Execute(object parameter)
        {
            try
            {
                if(_sellController.ItemsPack.Count == 0) 
                {
                    return;
                }
                foreach (var path in _sellController.ItemsPack)
                {
                    path.Id = MongoItems.GetUniqueId();
                    path.ShopName = _sellController._shopName;
                    MongoItems.ConnectAndAddFile(path);
                }

                try
                {
                    ShopConnector.EditItemInShop(_sellController.ItemsPack);
                }
                catch (Exception ex)
                {
                    _sellController.Response = "Ошибка";
                    return;
                }
                _sellController.Response = "Успешно";
            }
            catch (Exception ex)
            {
                _sellController.Response = "Ошибка";
            }
        }
    }
}

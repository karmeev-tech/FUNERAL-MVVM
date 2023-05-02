using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Storage;
using System.Collections.Generic;
using System.Windows.Documents;

namespace FUNERALMVVM.Commands.HeadStorage
{
    public class HeadStorageCommand : BaseCommands
    {
        private readonly HeadStorageController _headStorageController;
        private readonly IShopRepos _shopRepos = new ShopRepos();
        public HeadStorageCommand(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
        }

        public override void Execute(object parameter)
        {
            var items = _headStorageController.Items;
            List<string> picLinks = _shopRepos.GetPickLinks();
            int count = 0;
            foreach (var item in items) 
            {
                _shopRepos.UpdateDB(item, picLinks[count]);
                count++;
            }
            _headStorageController.Items = _shopRepos.GetItems();
        }
    }
}

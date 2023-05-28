using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.Storage;
using Infrastructure.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FuneralClient.Commands.Complect
{
    public class AddComplectCommand : BaseCommands
    {
        private readonly ComplectController _complectController;
        public AddComplectCommand(ComplectController complectController)
        {
            _complectController = complectController;
        }

        public override void Execute(object parameter)
        {
            var check = _complectController.Items.ToList();
            var duplicates = check.GroupBy(x => x.Name).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
            if(duplicates.Any())
            {
                MessageBox.Show("В списке есть повторяющиеся элементы");
                return;
            }
            try
            {
                MongoComplect.ConnectAndDeleteAllFiles();
                foreach (var item in _complectController.Items)
                {
                    item.Id = MongoComplect.GetUniqueId();
                    MongoComplect.ConnectAndAddFile(item);
                }

                _complectController.Response = "good";
            }
            catch (Exception ex)
            {
                _complectController.Response = "Ошибка";
            }
        }
    }
}

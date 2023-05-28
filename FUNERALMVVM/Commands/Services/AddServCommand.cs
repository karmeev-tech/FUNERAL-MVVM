using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel.Shop;
using Infrastructure.Model.Services;
using Infrastructure.Mongo;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FUNERALMVVM.Commands.Services
{
    public class AddServCommand : BaseCommands
    {
        private ServicesController _servicesController;

        public AddServCommand(ServicesController servicesController)
        {
            _servicesController = servicesController;
        }

        public override void Execute(object parameter)
        {
            try
            {
                MongoServices.ConnectAndDeleteAllFiles();
                foreach (var item in _servicesController.Services)
                {
                    item.Id = MongoServices.GetUniqueId();
                    MongoServices.ConnectAndAddFile(item);
                }

                _servicesController.ViewClosed();
            }
            catch
            {
                return;
            }
        }
        public async void AddDocument(List<ServiceEntity> serv, string fileName)
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, serv, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await createStream.DisposeAsync();
        }
    }
}

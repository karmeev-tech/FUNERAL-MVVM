using Domain.Services.Entity;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel.Shop;
using System.Collections.Generic;
using System.Configuration;
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
            List<Service> serv = new();
            foreach (var item in _servicesController.Services)
            {
                serv.Add(item);
            }
            string fileName = ConfigurationManager.AppSettings["ProgramWorkspaceDocs"] + "\\json\\ServicesDoc.json";
            AddDocument(serv, fileName);
            _servicesController.ViewClosed();
        }
        public async void AddDocument(List<Service> serv, string fileName)
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

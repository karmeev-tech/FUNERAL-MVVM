using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace FuneralClient.Commands.Complect
{
    public class AddComplectCommand : BaseCommands
    {
        private readonly ComplectController _complectController;
        private string _pathToDocs;

        public AddComplectCommand(ComplectController servicesController)
        {
            _complectController = servicesController;
            _pathToDocs = ConfigurationManager.AppSettings["ProgramWorkspaceDocs"];
        }

        public override void Execute(object parameter)
        {
            try
            {
                List<StorageItemEntity> result = new List<StorageItemEntity>();
                foreach (var item in _complectController.Items)
                {
                    result.Add(item);
                }

                string fileName = _pathToDocs + "\\json\\ComplectFuneralDoc.json";
                AddDocument(result, fileName);
                _complectController.Response = "good";
            }
            catch (Exception ex)
            {
                _complectController.Response = "Ошибка";
            }
        }

        public async void AddDocument(List<StorageItemEntity> complect, string fileName)
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, complect, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await createStream.DisposeAsync();
        }
    }
}

using Domain.Complect;
using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FuneralClient.Commands.Complect
{
    public class AddComplectCommand : BaseCommands
    {
        private readonly ComplectController _complectController;

        public AddComplectCommand(ComplectController servicesController)
        {
            _complectController = servicesController;
        }

        public override void Execute(object parameter)
        {
            try
            {
                List<ItemComplectEntity> result = new List<ItemComplectEntity>();
                foreach (var item in _complectController.Items)
                {
                    result.Add(new ItemComplectEntity()
                    {
                        Name = item.Name,
                        Money = item.Price,
                        Count = item.Count,
                        Procent = item.Procent,
                    });
                }

                string fileName = ".docs\\json\\ComplectFuneralDoc.json";
                AddDocument(result, fileName);
                _complectController.Response = "good";
            }
            catch (Exception ex)
            {
                _complectController.Response = "Ошибка";
            }
        }

        public async void AddDocument(List<ItemComplectEntity> complect, string fileName)
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

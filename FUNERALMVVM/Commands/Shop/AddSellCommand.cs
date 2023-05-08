using Domain.Complect;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
            if (!Directory.Exists(@".workspace\issue\send\iord") ||
                !Directory.Exists(@".workspace\issue\send\json"))
            {
                Directory.CreateDirectory(@".workspace\issue\send\iord");
                Directory.CreateDirectory(@".workspace\issue\send\json");
            }
            try
            {
                string fileName = @".workspace\issue\send\iord\item.json";
                AddDocument(_sellController.ItemsPack, fileName);
            }
            catch (Exception ex)
            {
                _sellController.Response = "Ошибка";
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

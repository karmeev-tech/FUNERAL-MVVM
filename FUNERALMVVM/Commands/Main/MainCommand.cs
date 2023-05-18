using Domain.GeneralOrder;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.ComplexMongo;
using OrderManager;
using System;
using System.IO;
using System.Text.Json;
using Worker;

namespace FUNERALMVVM.Commands.Main
{
    public class MainRequestCommand : BaseCommands
    {
        private readonly UsersController _controller;

        public MainRequestCommand(UsersController controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
            var requestSecond = new StateEntity();
            var request = new DordMeta()
            {
                ManagerName = _controller.UserName,
                StartWorkTime = new WorkerProvider().GetLastTimeFromJournalByName(_controller.UserName),
                EndWorkTime = DateTime.Now.ToString(),
            };
            AddDocument(request, @".workspace\issue\send\json\request.json");
        }

        public async void AddDocument(DordMeta request, string fileName)
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, request, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await createStream.DisposeAsync();
            Provider.GeneralIssueTransferring();
        }
    }

    public class MainResponseCommand : BaseCommands
    {
        private readonly UsersController _controller;

        public MainResponseCommand(UsersController controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
            //PickManager pickManager = new PickManager();
            //var file = pickManager.OpenManagerFileNameOrd();

            //Directory.CreateDirectory(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues");

            //File.Move(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.ord",
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip");

            //ZipFile.ExtractToDirectory(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip",
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues");

            //var files = Directory.GetFiles(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues\\funerals");

            //ObservableCollection<BaseIssueEntity> collection = new();

            //for (int i =0; i < files.Length; i++)
            //{
            //    string json = "";
            //    using (StreamReader r = new StreamReader(files[i]))
            //    {
            //        json = r.ReadToEnd();
            //    }

            //    collection.Add(
            //    JsonSerializer.Deserialize<BaseIssueEntity>(json));
            //}

            //int payments = 0;
            //foreach(var item in collection)
            //{
            //    payments += item.Payment;
            //}

            //string json2 = "";
            //using (StreamReader r = new StreamReader(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues\\headissue.json"))
            //{
            //    json2 = r.ReadToEnd();
            //}

            //MainEntity entity = 
            //    JsonSerializer.Deserialize<MainEntity>(json2);
            //entity.Money = payments.ToString();

            //_controller.BossTable.Add(entity);

            //File.Delete(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip");

            ////_controller.BossTable = collection;
        }
    }
}

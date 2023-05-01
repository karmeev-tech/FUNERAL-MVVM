using ClassLibrary;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Vml.Office;
using Domain.Issue;
using Domain.Main;
using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Worker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;

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
            IWorkerRepos workerRepos = new WorkerRepos();
            var worker = workerRepos.GetLastFromJournal();

            CopyDirectory(
            Directory.GetCurrentDirectory() + "\\.workspace\\docs",
            Directory.GetCurrentDirectory() + "\\.docs\\issue\\dockDays", true);

            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\.docs\\issue\\dockDays"); //Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.docx");
            List<string> fileNames = new();
            foreach (FileInfo file in Files)
            {
                fileNames.Add(file.Name);
            }
            var request = new MainManagerEntity()
            {
                ManagerName = worker,
                StartWorkTime = workerRepos.GetLastTimeFromJournalByName(worker),
                EndWorkTime = DateTime.Now.ToString(),
                Salary = _controller.Salary,
                Money = _controller.Money,
                FuneralSell = _controller.FuneralSell,
                LinksToScans = fileNames,
            };

            Send(request);
        }

        public async void Send(MainManagerEntity entity)
        {
            Directory.CreateDirectory(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\order");

            CopyDirectory(
               Directory.GetCurrentDirectory() + "\\.docs\\issue",
               Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\order", true);

            Directory.Delete(
                Directory.GetCurrentDirectory() + "\\.docs\\issue\\dockDays", true);


            using FileStream createStream = File.Create(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
                + "\\order\\headissue.json");

            await JsonSerializer.SerializeAsync(createStream, entity);
            await createStream.DisposeAsync();

            ZipFile.CreateFromDirectory(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\order",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip");

            Directory.Delete(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\order", true);

            File.Move(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.ord");

            //ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
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
            PickManager pickManager = new PickManager();
            var file = pickManager.OpenManagerFileNameOrd();

            Directory.CreateDirectory(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues");

            File.Move(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.ord",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip");

            ZipFile.ExtractToDirectory(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip",
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues");

            var files = Directory.GetFiles(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues\\funerals");

            ObservableCollection<IssueEntity> collection = new();

            for (int i =0; i < files.Length; i++)
            {
                string json = "";
                using (StreamReader r = new StreamReader(files[i]))
                {
                    json = r.ReadToEnd();
                }

                collection.Add(
                JsonSerializer.Deserialize<IssueEntity>(json));
            }

            int payments = 0;
            foreach(var item in collection)
            {
                payments += item.Payment;
            }

            string json2 = "";
            using (StreamReader r = new StreamReader(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issues\\headissue.json"))
            {
                json2 = r.ReadToEnd();
            }

            MainEntity entity = 
                JsonSerializer.Deserialize<MainEntity>(json2);
            entity.Money = payments.ToString();

            _controller.BossTable.Add(entity);

            File.Delete(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\issue.zip");

            //_controller.BossTable = collection;
        }
    }
}

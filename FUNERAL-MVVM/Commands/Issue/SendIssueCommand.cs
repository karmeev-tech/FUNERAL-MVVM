using Domain.Issue;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Worker;
using System;
using System.IO;
using System.Text.Json;

namespace FUNERALMVVM.Commands.Issue
{
    public class SendIssueCommand : BaseCommands
    {
        private readonly IssueController _controller;

        private readonly IWorkerRepos _repos;
        public SendIssueCommand(IssueController controller, IWorkerRepos repos)
        {
            _controller = controller;
            _repos = repos;
        }

        public override void Execute(object parameter)
        {
            if (_controller._scanLink == string.Empty && _controller._dockLink == string.Empty)
            {
                _controller.Response = "Прикрепите скан/отчёт";
            }
            else
            {
                var managerName = _repos.GetLastFromJournal();
                IssueEntity issue = new()
                {
                    Payment = int.Parse(_controller.Payment),
                    Prepayment = int.Parse(_controller.Prepayment),
                    ScanPath = _controller._scanLink, //место откуда мы кидаем сканы на босс пк
                    DockPath = _controller._dockLink, //место откуда мы кидаем отчёт на босс пк
                    ManagerName = managerName
                };
                SendIssue(issue);
            }
        }

        public async void SendIssue(IssueEntity issue)
        {
            using FileStream createStream = File.Create(".docs\\issue\\IssueBackup.json");
            await JsonSerializer.SerializeAsync(createStream, issue);
            await createStream.DisposeAsync();

            Random random = new();
            var numb = random.Next(1, 1000000).ToString();
            using FileStream createStream2 = File.Create(".docs\\issue\\funerals\\issue" + numb + ".json");
            await JsonSerializer.SerializeAsync(createStream2, issue);
            await createStream.DisposeAsync();

            _controller.Response = "Заявка принята";
            //string[] files = new string[] 
            //{ 
            //    ".docs\\issue\\IssueBackup.json" 
            //};
            //FormatCreator formatCreator = new FormatCreator();
            //if(!formatCreator.CreateOrdFile(files, ".docs\\issue\\issue.zip"))
            //{
            //    _controller.Response = "Ошибка";
            //}
            //else 
            //{
            //    _controller.Response = "Заявка принята";
            //}
        }
    }
}

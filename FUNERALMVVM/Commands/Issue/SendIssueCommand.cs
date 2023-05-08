using Domain.Issue;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Worker;
using OrderManager;
using System.IO;
using System.Text.Json;
using System;

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
            if (_controller.Payment == string.Empty || _controller.Prepayment == string.Empty)
            {
                _controller.Response = "Введено неверное число";
                return;
            }

            try
            {
                Convert.ToInt32(_controller.Payment);
                Convert.ToInt32(_controller.Prepayment);
            }
            catch(FormatException)
            {
                _controller.Response = "Введено неверное число";
                return;
            }

            if (_controller._scanLink == string.Empty || _controller._dockLink == string.Empty 
                || _controller._dock2Link == string.Empty || _controller._ord == string.Empty
                || _controller.Payment == string.Empty || _controller.Prepayment == string.Empty)
            {
                _controller.Response = "Прикрепите скан/отчёт";
            }
            else
            {
                var managerName = _repos.GetLastFromJournal();
                BaseIssueEntity issue = new()
                {
                    Payment = int.Parse(_controller.Payment),
                    Prepayment = int.Parse(_controller.Prepayment),
                    ScanPath = _controller._scanLink, //место откуда мы кидаем сканы на босс пк
                    DockPath = _controller._dockLink, //место откуда мы кидаем отчёт на босс пк
                    Dock2Path = _controller._dock2Link,
                    OrdPath = _controller._ord,
                    ManagerName = managerName
                };
                SendIssue(issue);
            }
        }

        public async void SendIssue(BaseIssueEntity issue)
        {
            try
            {
                Directory.CreateDirectory(@".workspace\issue\send\Transfer");
                string jsonpath = @".workspace\issue\send\Transfer\pocket147252.json";

                using FileStream createStream2 = File.Create(jsonpath);
                await JsonSerializer.SerializeAsync(createStream2, issue, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                await createStream2.DisposeAsync();

                Provider provider = new();
                Provider.IssueTransferring(jsonpath);

                _controller.Response = "Заявка принята";
            }
            catch(Exception)
            {
                _controller.Response = "Ошибка";
            }
        }
    }
}

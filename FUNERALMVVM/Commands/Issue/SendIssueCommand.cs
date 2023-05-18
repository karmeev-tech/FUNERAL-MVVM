using Domain.Issue;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Worker;
using OrderManager;
using System.IO;
using System.Text.Json;
using System;
using Infrastructure.Model.ComplexMongo;
using Domain.Complect;
using Domain.Order;
using Domain.Services.Entity;
using System.Collections.Generic;
using System.Linq;

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
            string number = _controller.Payment;

            //нам уже к этому моменту нужен жсончик

            SendIssue(number);
        }

        public async void SendIssue(string number)
        {
            try
            {
                var result = Provider.GetStates().Where(x => x.Id == Convert.ToInt32(number));

                if(result.Any()) 
                {
                    _controller.Response = "Заявка принята";
                }
                else
                {
                    _controller.Response = "Ошибка";

                }
            }
            catch(Exception)
            {
                _controller.Response = "Ошибка";
            }
        }
    }
}

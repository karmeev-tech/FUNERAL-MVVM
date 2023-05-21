using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Mongo;
using LegacyInfrastructure.Worker;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Worker.EF;

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
            try
            {
                File.Delete(ConfigurationManager.AppSettings["ProgramWorkspaceDocs"] + "\\json\\ServicesDoc.json");
                File.Delete(ConfigurationManager.AppSettings["ProgramWorkspaceDocs"] + "\\json\\ComplectFuneralDoc.json");

                int number = Convert.ToInt32(_controller.Payment);
                if (MongoFuneral.CheckDoc(Convert.ToInt32(number)) == false)
                {
                    return;
                }

                var id = Convert.ToInt32(number);
                if(WorkerConnector.GetState(id)!=new StateEntity())
                {
                    var result = Transfer();
                    if(result == 0)
                    {
                        _controller.Response = "Заявка принята";
                        return;
                    }
                };
                _controller.Response = "Ошибка";
                return;
            }
            catch (Exception ex)
            {
                _controller.Response = "Ошибка";
                return;
            }
        }

        public int Transfer()
        {
            string[] paths =
            {
                _controller._dock2Link, _controller._dockLink,_controller._scanLink
            };

            var check = paths.Where(x => x == string.Empty).ToList().Count;
            if(check != 0)
            {
                return -1;
            }

            var road = ConfigurationManager.AppSettings["ScanDocs"];

            string[] storage =
            {
                road + "\\" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "-"),
                road + "\\" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "-"),
                road + "\\" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "-")
            };
            Directory.CreateDirectory(storage[0]);
            Directory.CreateDirectory(storage[1]);
            Directory.CreateDirectory(storage[2]);

            string[] fileNames =
            {
                paths[0].Remove(0,paths[0].LastIndexOf(@"\")),
                paths[1].Remove(0,paths[1].LastIndexOf(@"\")),
                paths[2].Remove(0,paths[2].LastIndexOf(@"\"))
            };

            File.Copy(paths[0], storage[0] +  fileNames[0], true);
            File.Copy(paths[1], storage[1] + fileNames[1], true);
            File.Copy(paths[2], storage[2] + fileNames[2], true);
            return 0;
        }
    }
}

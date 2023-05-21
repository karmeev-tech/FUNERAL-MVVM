using BossInstruments;
using Domain.GeneralOrder;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using OrderManager;
using System.Configuration;
using System.IO;
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
            DordMetaFormalizer.SendDord(ConfigurationManager.AppSettings["Workspace"]);
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
        }
    }
}

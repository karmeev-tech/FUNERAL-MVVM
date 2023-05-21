using Domain.Services.Entity;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel.Shop;
using System;
using System.Linq;

namespace FuneralClient.Commands.Services
{
    public class AddServiceCommand : BaseCommands
    {
        private readonly ServicesController _servicesController;

        public AddServiceCommand(ServicesController servicesController)
        {
            _servicesController = servicesController;
        }

        public override void Execute(object parameter)
        {
            var name = _servicesController.ChooseService;
            var param = _servicesController.ChooseParam;
            var param2 = _servicesController.ChooseParam2;
            var information = _servicesController._listComplect.Where(x => x.Name == name).ToList();

            _servicesController.Services.Add(new Service()
            {
                Name = name,
                Money = information[0].Money,
                Count = information[0].Count,
                Param1 = param,
                Param2 = param2,
            });
        }
    }
}

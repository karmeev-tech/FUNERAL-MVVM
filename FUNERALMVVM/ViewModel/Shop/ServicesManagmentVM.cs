using FUNERAL_MVVM.Utility;
using Infrastructure.Model.Services;
using Shop.EF;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel.Shop
{
    public class ServicesManagmentVM : ViewModelBase
    {
        private ObservableCollection<ServiceEntity> services;

        public ServicesManagmentVM()
        {
            services = new ObservableCollection<ServiceEntity>(ServicesConnector.GetServices());
        }

        public ObservableCollection<ServiceEntity> Services
        {
            get => services;
            set
            {
                services = value;
                OnPropertyChanged(nameof(Services));
            }
        }

        public ICommand AddItem => new AddServiceItemCommand(this);
        public ICommand SendUpdate => new SendUpdateServiceCommand(this);

        public void DeleteServ(string param)
        {
            try
            {
                if (param == string.Empty)
                {
                    param = "";
                }
                var res = Services.Where(x => x.Name + x.Param1 != param).ToList();
                Services = new(res);
            }
            catch
            {
                MessageBox.Show("Проверьте написание");
            }
        }
    }

    public class AddServiceItemCommand : BaseCommands
    {
        public ServicesManagmentVM _controller;

        public AddServiceItemCommand(ServicesManagmentVM controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
            _controller.Services.Add(new ServiceEntity());
        }
    }

    public class SendUpdateServiceCommand : BaseCommands
    {
        public ServicesManagmentVM _controller;

        public SendUpdateServiceCommand(ServicesManagmentVM controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
            var send = _controller.Services.ToList();
            ServicesConnector.UpdateServices(send);
        }
    }
}

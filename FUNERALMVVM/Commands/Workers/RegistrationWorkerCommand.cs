using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel.Workers;
using Infrastructure.Model.Storage;
using Infrastructure.Model.Worker;
using IssueProvider;
using System;
using Worker.EF;

namespace FUNERALMVVM.Commands.Workers
{
    internal class RegistrationWorkerCommand : BaseCommands
    {
        private readonly RegistrationController _context;

        public RegistrationWorkerCommand(RegistrationController context)
        {
            _context = context;
        }

        public override void Execute(object parameter)
        {
            StorageEntity storageEntity = new() { Name = _context.Status };
            WorkerEntity userWorker = new();
            _context.Role = _context.Role.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            userWorker.Name = _context.Name;
            userWorker.Adress = _context.Adress;
            userWorker.Passport = _context.Passport;
            userWorker.Contacts = _context.Contacts;
            userWorker.Credentials = _context.Credentials;
            userWorker.Role = _context.Role;
            userWorker.ShopName = storageEntity.Name;
            userWorker.Password = _context.Password;

            try
            {
                WorkerConnector.AddWorker(userWorker);
                IssueCenter.AddWorkerSalary(userWorker.Name);
                _context.Closing();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}

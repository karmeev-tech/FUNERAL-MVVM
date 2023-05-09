using Domain.Worker;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Worker;
using Worker;

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
            UserWorker userWorker = new();
            userWorker.Name = _context.Name;
            userWorker.Adress = _context.Adress;
            userWorker.Passport = _context.Passport;
            userWorker.Contacts = _context.Contacts;
            userWorker.Credentials = _context.Credentials;
            userWorker.Role = _context.Role;
            userWorker.Status = _context.Status;
            userWorker.Password = _context.Password;

            //добавить проверку на наличие такого юзера
            WorkerProvider provider = new WorkerProvider();
            var result = provider.AddWorker(userWorker);

            if(result == "error")
            {
                return;
            }
            else
            {
                _context.Closing();
            }
        }
    }
}

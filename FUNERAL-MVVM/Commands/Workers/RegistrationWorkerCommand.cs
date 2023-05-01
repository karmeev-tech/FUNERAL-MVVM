using Domain.Worker;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using Infrastructure.Worker;

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
            userWorker.Role = _context.Role;
            userWorker.Password = _context.Password;
            userWorker.Passport = _context.Passport;
            userWorker.Contacts = _context.Contacts;
            userWorker.Credentials = _context.Credentials;
            //добавить проверку на наличие такого юзера
            WorkerRepos repos = new();
            repos.AddWorker(userWorker);
        }
    }
}

using LegacyInfrastructure.Worker;

namespace Model.Worker
{
    public class Auth
    {
        private readonly string _name;
        private readonly string _password;

        public Auth(string name, string password)
        {
            _name = name;
            _password = password;
        }

        public string TryAuth(IWorkerRepos workerRepos)
        {
            if (_name is not null && _name is not "")
            {
                if (workerRepos.AuthenticatedWorker(_name, _password) is "ok")
                {
                    // db say yes
                    workerRepos.SendToJournal(_name);
                    return "ok";
                }
                else
                {
                    // db say no
                    return "Ошибка авторизации";
                }
            }

            return "Ошибка авторизации";
        }
    }
}

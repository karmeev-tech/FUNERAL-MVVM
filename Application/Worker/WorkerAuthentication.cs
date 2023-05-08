using LegacyInfrastructure.Worker;

namespace Worker
{
    internal class WorkerAuthentication
    {
        private readonly IWorkerRepos _workerRepos;

        public WorkerAuthentication(IWorkerRepos workerRepos)
        {
            _workerRepos = workerRepos;
        }

        public string Auth(string name, string password)
        {
            if (name is not null && name is not "")
            {
                if (_workerRepos.AuthenticatedWorker(name, password) is "ok")
                {
                    _workerRepos.SendToJournal(name);
                    return "ok";
                }
                else
                {
                    return "Ошибка авторизации";
                }
            }

            return "Ошибка авторизации";
        }
    }
}

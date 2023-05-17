using Domain.Dord;
using Domain.Worker;
using LegacyInfrastructure.Worker;

namespace Worker
{
    public class WorkerProvider
    {
        private readonly IWorkerRepos _workerRepos = new WorkerRepos();

        public string GetLastTimeFromJournalByName(string name)
        {
            WorkerInformation workerInformation = new(_workerRepos);
            return workerInformation.GetLastTimeFromJournalByName(name);
        }
        public string Auth(string username, string password)
        {
            WorkerAuthentication workerAuthentication = new(_workerRepos);
            return workerAuthentication.Auth(username, password);
        }
        public string AddWorker(UserWorker worker)
        {
            var repos = _workerRepos.GetWorkers();
            var clerks = repos.Where(x => x != worker.Name);
            if(clerks.Any())
            {
                WorkerAuthentication workerAuthentication = new(_workerRepos);
                workerAuthentication.AddWorker(worker);
                return "complete";
            }
            else
            {
                return "error";
            }
        }
        public string DeleteWorker(string name)
        {
            var repos = _workerRepos.GetWorkers();
            var clerks = repos.Where(x => x == name);
            if (clerks.Any())
            {
                WorkerAuthentication workerAuthentication = new(_workerRepos);
                workerAuthentication.DeleteWorker(_workerRepos.GetWorkerById(name));
                return "complete";
            }
            else
            {
                return "error";
            }
        }
        public List<string> GetWorkers()
        {
            return new WorkerInformation(_workerRepos).GetWorkers();
        }
        public string GetWorkerRole(string name)
        {
            return new WorkerInformation(_workerRepos).GetWorkerRole(name);
        }
        public DordEntity GetDordWorkerInformation(string jsonLink)
        {
            return new WorkerInformation(_workerRepos).GetDordWorkerInformation(jsonLink);
        }
    }
}

using Domain.Dord;
using LegacyInfrastructure.Worker;

namespace Worker
{
    public class WorkerInformation
    {
        private readonly IWorkerRepos _workerRepos;

        public WorkerInformation(IWorkerRepos workerRepos)
        {
            _workerRepos = workerRepos;
        }

        public string GetLastTimeFromJournalByName(string name)
        {
            return _workerRepos.GetLastTimeFromJournalByName(name);
        }
        public List<string> GetWorkers()
        {
            return _workerRepos.GetWorkers();
        }

        public string GetWorkerRole(string name)
        {
            return _workerRepos.GetWorkerRole(name);
        }

        public DordEntity GetDordWorkerInformation(string jsonLink)
        {
            return new DordEntity();
        }
    }
}

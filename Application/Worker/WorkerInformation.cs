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
    }
}

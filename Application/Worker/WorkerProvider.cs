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
    }
}

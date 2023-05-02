using Domain.Worker;

namespace LegacyInfrastructure.Worker
{
    public interface IWorkerRepos
    {
        void GetWorkers();
        UserWorker GetWorkerInfo(string name);
        void SendToJournal(string name);
        string AuthenticatedWorker(string name, string password);
        string GetLastFromJournal();
        string GetLastRoleFromJournal(string name);
        public string GetLastTimeFromJournalByName(string name);
    }
}

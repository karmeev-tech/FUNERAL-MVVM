using Domain.Worker;

namespace LegacyInfrastructure.Worker
{
    public interface IWorkerRepos
    {
        public List<string> GetWorkers();
        UserWorker GetWorkerInfo(string name);
        void SendToJournal(string name);
        string AuthenticatedWorker(string name, string password);
        string GetLastFromJournal();
        string GetLastRoleFromJournal(string name);
        public string GetLastTimeFromJournalByName(string name);
        public void AddWorker(UserWorker worker);
        public void DeleteWorker(int id);
        public int GetWorkerById(string name);
        public string GetWorkerRole(string name);
    }
}

namespace Infrastructure.Worker
{
    public interface IWorkerRepos
    {
        void GetWorkers();
        string[] GetWorkerInfo(string name);
        void SendToJournal(string name);
        string AuthenticatedWorker(string name, string password);
    }
}

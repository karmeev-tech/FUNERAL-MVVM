using Infrastructure.Context.Issue;
using Infrastructure.Context.Salary;
using Infrastructure.Context.State;
using Infrastructure.Context.Storage;
using Infrastructure.Context.Worker;
using Infrastructure.Mongo;
using System.Diagnostics;

namespace ConfigBoss
{
    public class Init
    {
        public void Connect()
        {
            //ConnectToWorker();
            //ConnectToStorage();
            //ConnectToState();
            //ConnectToIssue();
            //ConnectToSalary();
            //ConnectToShops();
            ConnectToMongo();
        }
        private static void ConnectToMongo()
        {
            MongoFuneral.Connect();
            //MongoFuneral.GetUniqueId();

            //Process process = new Process();
            //process.StartInfo.FileName = "net.exe";
            //process.StartInfo.Arguments = "start MongoDB";
            //process.Start();

            //string output = process.StandardOutput.ReadToEnd();

            //process.WaitForExit();
        }

        private static void ConnectToIssue()
        {
            using (var context = new IssueContext())
            {
                //context.Database.Migrate();
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }

        private static void ConnectToStorage()
        {
            using (var db = new StorageContext())
            {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }
        }

        private static void ConnectToWorker()
        {
            using (var db = new WorkerContext())
            {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }
        }

        private static void ConnectToState()
        {
            using (var db = new StateContext())
            {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }
        }

        private static void ConnectToSalary()
        {
            using (var db = new SalaryContext())
            {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }
        }

        private static void ConnectToShops()
        {
            using (var db = new ShopsContext())
            {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }
        }
    }
}

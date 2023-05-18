using Domain.Order;
using Infrastructure.Context.Issue;
using Infrastructure.Context.Worker;
using Infrastructure.Model.Issue;
using Infrastructure.Model.Storage;
using Infrastructure.Model.Worker;

namespace Worker.EF
{
    public class WorkerConnector
    {
        public string AddWorker(WorkerEntity workerEntity)
        {
            using (var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            orderby b.Name
                            where b.Name == workerEntity.Name
                            select b;

                if (query.Any())
                {
                    return "error";
                }

                db.Workers.Add(workerEntity);
                db.SaveChanges();
            }

            using (var db = new IssueContext()) 
            {
                var query = from b in db.IssueMoney
                            orderby b.Name
                            where b.Name == workerEntity.Name
                            select b;
                if (query.Any())
                {
                    return "error";
                }
                db.IssueMoney.Add(new IssueEntity() { Name = workerEntity.Name , Money = 0});
                db.SaveChanges();
            }
            return "ok";
        }

        public static void DeleteWorker(string name)
        {
            using (var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            where b.Name == name
                            select b;

                if (!query.Any())
                {
                    return;
                }

                db.Workers.Remove(query.First());
                db.SaveChanges();
            }

            using(var db = new IssueContext())
            {
                var query = from b in db.IssueMoney
                            where b.Name == name
                            select b;
                db.IssueMoney.Remove(query.First());
            }
        }

        public static string GetWorkerRole(string name)
        {
            using (var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            where b.Name == name
                            select b.Role;
                if (!query.Any())
                {
                    return "error";
                }
                else
                {
                    return query.First();
                }
            }
        }

        public static string Auth(string name, string password)
        {
            using(var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            where b.Name == name && b.Password == password
                            select b;
                if (!query.Any())
                {
                    return "error";
                }
                else
                {
                    return "ok";
                }
            }
        }

        public static string GetWorkerShop(string name)
        {
            using (var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            where b.Name == name
                            select b.ShopName.Name;
                
                return query.First();
            }
        }

        public static List<string> GetWorkers()
        {
            using (var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            select b.Name;
                return query.ToList();
            }
        }
    }
}

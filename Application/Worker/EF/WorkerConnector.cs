using Infrastructure.Context.Issue;
using Infrastructure.Context.Salary;
using Infrastructure.Context.State;
using Infrastructure.Context.Worker;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Issue;
using Infrastructure.Model.Salary;
using Infrastructure.Model.Worker;

namespace Worker.EF
{
    public class WorkerConnector
    {
        public static void AddWorker(WorkerEntity workerEntity)
        {
            using (var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            orderby b.Name
                            where b.Name == workerEntity.Name
                            select b;

                if (query.Any())
                {
                    return;
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
                    return;
                }
                db.IssueMoney.Add(new IssueEntity() { Name = workerEntity.Name, Money = 0 });
                db.SaveChanges();
            }
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
            using (var db = new WorkerContext())
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
                            select b.ShopName;

                return query.First();
            }
        }

        public static List<WorkerEntity> GetWorkers()
        {
            using (var db = new WorkerContext())
            {
                var query = from b in db.Workers
                            select b;
                return query.ToList();
            }
        }

        public static List<SalaryEntity> GetAllSalary()
        {
            List<SalaryEntity> result = new();
            using (var db = new SalaryContext())
            {
                result = db.IssueMoney.ToList();

            }
            return result;
        }

        public static StateEntity GetState(int id)
        {
            using (var db = new StateContext())
            {
                var query = from b in db.State
                            where b.Id == id
                            select b;

                if (query.Any())
                {
                    return query.First();
                }

                return new StateEntity();
            }
        }

        public static void UpdateAllWorkers(List<WorkerEntity> workers)
        {
            using (var db = new WorkerContext())
            {
                db.Workers.RemoveRange(db.Workers.ToList());
                db.SaveChanges();
                foreach (var workerEntity in workers)
                {
                    db.Workers.Add(workerEntity);
                }
                db.SaveChanges();
            }
        }
    }
}

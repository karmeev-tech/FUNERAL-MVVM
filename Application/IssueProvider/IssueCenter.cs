using Infrastructure.Context.Issue;
using Infrastructure.Context.Salary;
using Infrastructure.Context.Storage;
using Infrastructure.Model.Issue;
using Infrastructure.Model.Salary;
using Infrastructure.Model.Storage;
using Infrastructure.Model.Worker;
using System.Xml.Linq;

namespace IssueProvider
{
    public class IssueCenter
    {
        public void SendToDB(IssueEntity issueEntity)
        {

        }

        public static List<SalaryEntity> GetAllFromDB()
        {
            var result = new List<SalaryEntity>();
            using (var db = new SalaryContext())
            {
                var query = from issue in db.IssueMoney
                            select issue;
                result = query.ToList();
            }
            return result;
        }

        public static void AddWorkerSalary(string name)
        {
            using (var db = new SalaryContext())
            {
                var query = from b in db.IssueMoney.Select(selector => selector.WorkerName)
                            where b == name
                            select b;

                if (query.Any())
                {
                    return;
                }

                var query2 = from b in db.IssueMoney
                             orderby b.Id
                             select b.Id;

                var id = query2.ToList().Last();

                db.IssueMoney.Add(new SalaryEntity() { Id = id + 1, WorkerName = name, WorkerMoney = 0 });
                db.SaveChanges();
            }
        }

        public static void DeleteSalary(string name)
        {
            using (var db = new SalaryContext())
            {
                var query = from b in db.IssueMoney
                            orderby b.WorkerName
                            where b.WorkerName == name
                            select b;
                if (!query.Any())
                {
                    return;
                }
                db.IssueMoney.Remove(query.First());
                db.SaveChanges();
            }
        }

        public static void UpdateSalaryWorker(string workerName, int money)
        {
            using(var db = new SalaryContext())
            {
                var query = from b in db.IssueMoney
                            where b.WorkerName == workerName
                            select b;
                if (!query.Any())
                {
                    return;
                }
                SalaryEntity updateSalary = query.First();
                db.IssueMoney.Remove(query.First());
                updateSalary.WorkerMoney = money; 
                db.SaveChanges();
            }
        }
    }
}
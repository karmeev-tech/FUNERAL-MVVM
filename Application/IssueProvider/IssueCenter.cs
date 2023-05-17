using Infrastructure.Context.Issue;
using Infrastructure.Model.Issue;

namespace IssueProvider
{
    public class IssueCenter
    {
        public void SendToDB(IssueEntity issueEntity)
        {

        }

        public static void UpdateDB(List<IssueEntity> issueEntity) 
        {
            using (var context = new IssueContext())
            {
                List<IssueEntity> list = context.IssueMoney.ToList();
                context.IssueMoney.RemoveRange(list);
                context.IssueMoney.AddRange(issueEntity);
                context.SaveChanges();
            }
        }

        public static List<IssueEntity> GetFromDB(string userName)
        {
            var result = new List<IssueEntity>(); 
            using (var db = new IssueContext())
            {
                var query = from issue in db.IssueMoney
                            where issue.Name == userName
                            select issue;
                result = query.ToList();
            }
            return result;
        }

        public static List<IssueEntity> GetAllFromDB()
        {
            var result = new List<IssueEntity>();
            using (var db = new IssueContext())
            {
                var query = from issue in db.IssueMoney
                            select issue;
                result = query.ToList();
            }
            return result;
        }
    }
}
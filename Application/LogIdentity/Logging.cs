using Infrastructure.Context.Log;
using Infrastructure.Model.Log;

namespace LogIdentity
{
    public class Logging
    {
        public void Log(string name)
        {
            using (var db = new LogContext())
            {
                var entity = new LogEntity { Name = name, DateTime = DateTime.Now.ToString() };
                db.Logs.Add(entity);
                db.SaveChanges();
            }
        }
    }
}

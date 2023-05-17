using Infrastructure.Context.Worker;
using Infrastructure.Model.Worker;

namespace ConsoleApp1
{
    public class EFChecas
    {
        public void Check()
        {
            using (var db = new WorkerContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new shop: ");
                var name = Console.ReadLine();
                var blog = new WorkerEntity { Name = name };

                db.Workers.Add(blog);
                db.SaveChanges();
            }
        }
    }
}

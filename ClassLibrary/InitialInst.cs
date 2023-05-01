using ClassLibrary.Domain;
using System;
using System.Data.Linq;
using System.Linq;

namespace ClassLibrary
{
    public class InitialInst
    {
        public void InitialInst2(string nameDB, string name, int money)
        {
            DataContext db = new DataContext(@"E:\work\projects\FUNERAL-MVVM\ConsoleApp1\bin\Debug\net7.0\.base\SalaryDB.mdf");
            Table<BaseSalary> Workers = db.GetTable<BaseSalary>();
            // Attach the log to show generated SQL.
            db.Log = Console.Out;

            // Query for customers in London.
            IQueryable<BaseSalary> custQuery =
                from cust in Workers
                where cust.Name == name
                select cust;
        }
    }
}

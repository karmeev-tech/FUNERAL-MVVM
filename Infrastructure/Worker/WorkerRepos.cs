using Domain.Worker;
using Infrastructure.Connector;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Reflection.Metadata;

namespace Infrastructure.Worker
{
    public class WorkerRepos : GenConnector, IWorkerRepos
    {
        public string AuthenticatedWorker(string name, string password)
        {
            Connect("WorkerDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Worker",_sqlConnection);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<UserWorker> workers = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                workers.Add(new UserWorker
                {
                    Id = (int)dr[0],
                    Name = dr[1].ToString(),
                    Adress = dr[2].ToString(),
                    Passport = dr[3].ToString(),
                    Contacts = dr[4].ToString(),
                    Credentials = dr[5].ToString(),
                    Role = dr[6].ToString(),
                    Password = dr[7].ToString()
                });
            }
            sqlDataAdapter.Dispose();
            Close();
            if(workers.Count > 0 )
            {
                foreach (var worker in workers)
                {
                    if (worker.Name == name && worker.Password == password)
                    {
                        return "ok";
                    }
                }
            }
            return "not okay";
        }

        public string[] GetWorkerInfo(string name)
        {
            //return new string[4] {"value", "value", "value", "value"};
            // connect to DB and return data
            Connect("LogDB");

            throw new NotImplementedException();
        }

        public void GetWorkers()
        {
            // connect to DB and return data
            Connect("LogDB");
            throw new NotImplementedException();
        }

        public void SendToJournal(string name)
        {
            Connect("LogDB");
            SqlCommand command = new SqlCommand(
                "INSERT INTO [Logs] (Name, Date) VALUES (@Name, @Date)"
                , _sqlConnection);
            command.Parameters.AddWithValue("Name", name);
            DateTime dateTime = DateTime.Today;
            command.Parameters.AddWithValue("Date", dateTime);
            command.ExecuteNonQuery();
            Close();
        }
    }
}

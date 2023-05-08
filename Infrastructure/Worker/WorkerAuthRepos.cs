using Domain.Worker;
using LegacyInfrastructure.Connector;
using System.Data;
using System.Data.SqlClient;

namespace LegacyInfrastructure.Worker
{
    public partial class WorkerRepos : GenConnector, IWorkerRepos
    {
        public string AuthenticatedWorker(string name, string password)
        {
            Connect("WorkerDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Worker",_sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<UserWorker> workers = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                workers.Add(new UserWorker
                {
                    Id = (int)dr[0],
                    Name = dr[1]?.ToString(),
                    Adress = dr[2]?.ToString(),
                    Passport = dr[3]?.ToString(),
                    Contacts = dr[4]?.ToString(),
                    Credentials = dr[5]?.ToString(),
                    Role = dr[6]?.ToString(),
                    Password = dr[8]?.ToString()
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

        public void SendToJournal(string name)
        {
            Connect("LogDB");
            SqlCommand command = new(
                "INSERT INTO [Logs] (Name, Date) VALUES (@Name, @Date)"
                , _sqlConnection);
            command.Parameters.AddWithValue("Name", name);

            DateTime dateTime = DateTime.Now;
            command.Parameters.AddWithValue("Date", dateTime.ToString());
            command.ExecuteNonQuery();
            Close();
        }
        //must be optimized to Tuple!
        public string GetLastFromJournal()
        {
            Connect("LogDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Logs", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            var name = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                name = dr["Name"].ToString();
            }
            sqlDataAdapter.Dispose();
            Close();
            return name;
        }
        public string GetLastTimeFromJournalByName(string name)
        {
            Connect("LogDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Logs WHERE Name = '" + name + "'", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            var date = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if(name == dr["Name"].ToString())
                {
                    date = dr["Date"].ToString();
                }
            }
            sqlDataAdapter.Dispose();
            Close();
            return date;
        }
        public string GetLastRoleFromJournal(string name)
        {
            Connect("WorkerDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Worker", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            var role = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if(name == dr[1].ToString())
                {
                    role = dr[6]?.ToString();
                }
            }
            sqlDataAdapter.Dispose();
            Close();
            return role;
        }
    }
}

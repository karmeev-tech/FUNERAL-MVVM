using Domain.Worker;
using LegacyInfrastructure.Connector;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace LegacyInfrastructure.Worker
{
#nullable disable
    public partial class WorkerRepos : GenConnector, IWorkerRepos
    {
        public UserWorker GetWorkerInfo(string name)
        {
            ////return new string[4] {"value", "value", "value", "value"};
            //// connect to DB and return data
            //string name = GetLastWorker();
            Connect("WorkerDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Worker", _sqlConnection);

            List<UserWorker> workers = new();

            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
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
                    Status = dr[7]?.ToString(),
                    Password = dr[8]?.ToString()
                });
            }
            sqlDataAdapter.Dispose();
            Close();

            foreach (UserWorker worker in workers)
            {
                if(name == worker.Name)
                {
                    return worker;
                }
            }
            return new UserWorker();
        }

        public List<string> GetWorkers()
        {
            // connect to DB and return data
            Connect("WorkerDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT Name FROM Worker", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<string> name = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                name.Add(dr["Name"].ToString());
            }
            sqlDataAdapter.Dispose();
            Close();
            return name;
        }

        public void AddWorker(UserWorker worker)
        {
            Connect("WorkerDB");
            SqlCommand command = new(
                "INSERT INTO [Worker] (Name, Adress, Passport, Contacts, Credentials, Role, Status, Password) " +
                "VALUES (@Name, @Adress, @Passport, @Contacts, @Credentials, @Role, @Status, @Password)"
                , _sqlConnection);
            command.Parameters.AddWithValue("Name", worker.Name);
            command.Parameters.AddWithValue("Adress", worker.Adress);
            command.Parameters.AddWithValue("Passport", worker.Passport);
            command.Parameters.AddWithValue("Contacts", worker.Contacts);
            command.Parameters.AddWithValue("Credentials", worker.Credentials);
            command.Parameters.AddWithValue("Role", worker.Role);
            command.Parameters.AddWithValue("Status", worker.Status);
            command.Parameters.AddWithValue("Password", worker.Password);
            command.ExecuteNonQuery();
            Close();
        }

        public void DeleteWorker(int id)
        {
            Connect("WorkerDB");
            SqlCommand command = new("DELETE FROM Worker WHERE Id = " + id.ToString(), _sqlConnection);
            command.ExecuteNonQuery();
            Close();
        }

        public int GetWorkerById(string name)
        {
            Connect("WorkerDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Worker WHERE Name = '" + name + "'", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<string> names = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                names.Add(dr["Id"].ToString());
            }
            sqlDataAdapter.Dispose();
            Close();
            return Convert.ToInt32(names[0]);
        }
        public string GetWorkerRole(string name)
        {
            Connect("WorkerDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Worker WHERE Name = '" + name + "'", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<string> names = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                names.Add(dr["Role"].ToString());
            }
            sqlDataAdapter.Dispose();
            Close();
            return names[0];
        }
    }
}

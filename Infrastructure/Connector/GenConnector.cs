using Infrastructure.Worker;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Connector
{
    public class GenConnector
    {
        public SqlConnection _sqlConnection = null;
        public void Connect(string nameDB)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[nameDB].ConnectionString);
            _sqlConnection.Open();
            if(_sqlConnection.State is ConnectionState.Open)
            {
                Console.WriteLine("DB connected");
            }
        }
        public void Close()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Connector
{
#nullable disable
    public class GenConnector
    {
        public SqlConnection _sqlConnection = null;
        public void Connect(string nameDB)
        {
            var conStr = InitialInst(nameDB);
            _sqlConnection = new SqlConnection(conStr);
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

        private static string InitialInst(string name)
        {
            ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[name];
            return c.ConnectionString.Replace("{path}", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}

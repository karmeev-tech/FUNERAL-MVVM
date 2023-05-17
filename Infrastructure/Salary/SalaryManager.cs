using LegacyInfrastructure.Connector;
using System.Data;
using System.Data.SqlClient;

namespace LegacyInfrastructure.Salary
{
    public class SalaryManager : GenConnector
    {
        public void UpdateSalary(string name, int money)
        {
            int id = GetSalaryId(name);
            int moneyOld = GetSalaryMoney(name);
            moneyOld = moneyOld + money;
            Connect("SalaryDB");
            SqlCommand command = new(
                "UPDATE [Salary] SET Money = " + moneyOld.ToString() + " WHERE Id = " + id
                , _sqlConnection);
            command.ExecuteNonQuery();
            Close();
        }

        public int GetSalaryId(string name)
        {
            Connect("SalaryDB");
            int id = 0;
            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Salary", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (name == dr[1].ToString().Replace(" ", ""))
                {
                    id = Convert.ToInt32(dr[0].ToString());
                }
            }
            sqlDataAdapter.Dispose();
            Close();
            return id;
        }

        public int GetSalaryMoney(string name)
        {
            Connect("SalaryDB");
            int money = 0;
            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Salary", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (name == dr[1].ToString().Replace(" ", ""))
                {
                    money = Convert.ToInt32(dr[2].ToString());
                }
            }
            sqlDataAdapter.Dispose();
            Close();
            return money;
        }
    }
}

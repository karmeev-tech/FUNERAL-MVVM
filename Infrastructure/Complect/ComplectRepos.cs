using Domain.Complect;
using Legacy.Infrastructure.Complect;
using LegacyInfrastructure.Connector;
using System.Data;
using System.Data.SqlClient;

namespace LegacyInfrastructure.Complect
{
    public class ComplectRepos : GenConnector, IComplectRepos
    {
        public List<ItemComplectEntity> GetItems()
        {
            Connect("StorageDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT Name, Price, Count, Procent FROM Storage", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<ItemComplectEntity> items = new List<ItemComplectEntity>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                items.Add(new ItemComplectEntity()
                {
                    Name = dr[0].ToString(),
                    Money = Convert.ToInt32(dr[1].ToString()),
                    Count = Convert.ToInt32(dr[2].ToString()),
                    Procent = Convert.ToInt32(dr[3].ToString())
                });
            }
            return items;
        }
    }
}

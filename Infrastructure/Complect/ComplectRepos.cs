using Domain.Shop;
using LegacyInfrastructure.Connector;
using System.Data;
using System.Data.SqlClient;

namespace LegacyInfrastructure.Complect
{
    public class ComplectRepos : GenConnector
    {
        //public List<StorageItemEntity> GetItems()
        //{
        //    Connect("StorageDB");
        //    SqlDataAdapter sqlDataAdapter = new("SELECT Name, Price, Count, Procent FROM Storage", _sqlConnection);
        //    DataSet ds = new();
        //    sqlDataAdapter.Fill(ds);
        //    ds.IsInitialized.ToString();
        //    List<ItemComplectEntity> items = new List<ItemComplectEntity>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        items.Add(new ItemComplectEntity()
        //        {
        //            Name = dr[0].ToString(),
        //            Money = Convert.ToInt32(dr[1].ToString()),
        //            Count = Convert.ToInt32(dr[2].ToString()),
        //            Procent = Convert.ToInt32(dr[3].ToString())
        //        });
        //    }
        //    return items;
        //}

        public List<ShoppingItem> GetAllItems()
        {
            Connect("StorageDB");
            SqlDataAdapter sqlDataAdapter = new("SELECT Name, Price, ZakupPrice, Count, Procent FROM Storage", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<ShoppingItem> items = new List<ShoppingItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                items.Add(new ShoppingItem()
                {
                    Name = dr[0].ToString(),
                    Price = Convert.ToInt32(dr[1].ToString()),
                    ZakupPrice = Convert.ToInt32(dr[2].ToString()),
                    Count = Convert.ToInt32(dr[3].ToString()),
                    Procent = Convert.ToInt32(dr[4].ToString())
                });
            }
            return items;
        }
    }
}

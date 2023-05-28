using LegacyInfrastructure.Connector;

namespace Legacy.Infrastructure.Services
{
    public class ServiceRepos : GenConnector
    {
        //public List<Service> GetServices()
        //{
        //    Connect("MaterialDB");
        //    SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Material", _sqlConnection);
        //    DataSet ds = new();
        //    sqlDataAdapter.Fill(ds);
        //    ds.IsInitialized.ToString();
        //    List<Service> services = new List<Service>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        services.Add(new Service()
        //        {
        //            Id = (int)dr[0],
        //            Name = dr[1]?.ToString(),
        //            Money = Convert.ToInt32(dr[2]?.ToString()),
        //            Count = Convert.ToInt32(dr[3]?.ToString()),
        //            Param1 = dr[4]?.ToString(),
        //            Param2 = dr[5]?.ToString(),
        //        });
        //    }
        //    sqlDataAdapter.Dispose();
        //    Close();
        //    return services;
        //}

        //public List<string> GetServicesByName()
        //{
        //    Connect("MaterialDB");
        //    SqlDataAdapter sqlDataAdapter = new("SELECT Name FROM Material", _sqlConnection);
        //    DataSet ds = new();
        //    sqlDataAdapter.Fill(ds);
        //    ds.IsInitialized.ToString();
        //    List<string> services = new List<string>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        services.Add(dr[0].ToString());
        //    }
        //    sqlDataAdapter.Dispose();
        //    Close();
        //    return services;
        //}
    }
}

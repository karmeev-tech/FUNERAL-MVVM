using ClassLibrary;
using Domain.Shop;
using LegacyInfrastructure.Connector;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace LegacyInfrastructure.Storage
{
    public class ShopRepos : GenConnector, IShopRepos
    {
        [Obsolete]
        public string AddItemToDB(ShopItem item)
        {
            Connect("StorageDB");
            PickManagerExtendet pickManager = new();
            pickManager.AddToWorkspace();
            if(pickManager.CheckNotEmpty() == "not empty") 
            {
                SqlCommand command = new(
                "INSERT INTO [Storage] (Name, Type, Price, PickLink, ZakupPrice, OForm, TForm, GForm, Margin, Color, Polishing, Other, Count) " +
                "VALUES (" +
                "@Name, @Type, @Price, @PickLink, @ZakupPrice, @OForm, @TForm, @GForm, @Margin, @Color, @Polishing, @Other, @Count" +
                ")"
                , _sqlConnection);
                command.Parameters.AddWithValue("Name", item.Name);
                command.Parameters.AddWithValue("Type", item.Type);
                command.Parameters.AddWithValue("Price", item.Price);
                command.Parameters.AddWithValue("PickLink", pickManager.GetCurrentDir());
                command.Parameters.AddWithValue("ZakupPrice", item.ZakupPrice);
                command.Parameters.AddWithValue("OForm", item.OForm);
                command.Parameters.AddWithValue("TForm", item.TForm);
                command.Parameters.AddWithValue("GForm", item.GForm);
                command.Parameters.AddWithValue("Margin", item.Margin);
                command.Parameters.AddWithValue("Color", item.Color);
                command.Parameters.AddWithValue("Polishing", item.Polishing);
                command.Parameters.AddWithValue("Other", item.Other);
                command.Parameters.AddWithValue("Count", 0);
                command.ExecuteNonQuery();
                Close();
                return "nice";
            }
            else
            {
                Close();
                return "bad";
            }
        }

        public void UpdateDB(ShoppingItem item)
        {
            Connect("StorageDB");
            SqlCommand command = new(
                "DELETE FROM [Storage] WHERE Name = @Name"
                , _sqlConnection);
            command.Parameters.AddWithValue("Name", item.Name);
            command.ExecuteNonQuery();
            Close();

            Connect("StorageDB");
            SqlCommand command2 = new(
                "INSERT INTO [Storage] (Name, Price, ZakupPrice, Count, Procent) " +
                "VALUES (@Name, @Price, @ZakupPrice, @Count, @Procent)"
                , _sqlConnection);
            command2.Parameters.AddWithValue("Name", item.Name);
            command2.Parameters.AddWithValue("Price", item.Price);
            command2.Parameters.AddWithValue("ZakupPrice", item.ZakupPrice);
            command2.Parameters.AddWithValue("Count", item.Count);
            command2.Parameters.AddWithValue("Procent", item.Procent);
            command2.ExecuteNonQuery();
            Close();
        }

        public string IdentityCheck(ShopItem item)
        {
            Connect("StorageDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT Name FROM Storage", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<string> itemNames = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                itemNames.Add(dr[0].ToString());
            }
            sqlDataAdapter.Dispose();
            Close();
            foreach (string itemName in itemNames)
            {
                if(itemName==item.Name)
                {
                    return "Уже существует";
                }
            }
            return "";
        }

        public List<string> GetItemNames()
        {
            Connect("StorageDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT Name FROM Storage", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<string> itemNames = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                itemNames.Add(dr[0].ToString());
            }
            sqlDataAdapter.Dispose();
            Close();
            return itemNames;
        }

        public ObservableCollection<ShopItem> GetItems()
        {
            Connect("StorageDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT * FROM Storage", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            ObservableCollection<ShopItem> itemNames = new();
            List<string> items = new List<string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                itemNames.Add(new ShopItem()
                {
                    Name = dr[1].ToString(),
                    Type = dr[2].ToString(),
                    Price = Convert.ToInt32(dr[3].ToString()),
                    ZakupPrice = Convert.ToInt32(dr[4].ToString()),
                    OForm = dr[6].ToString(),
                    TForm = dr[7].ToString(),
                    GForm = dr[8].ToString(),
                    Margin = dr[9].ToString(),
                    Color = dr[10].ToString(),
                    Polishing = dr[11].ToString(),
                    Other = dr[12].ToString(),
                    Count = Convert.ToInt32(dr[13].ToString())
                });
            }
            sqlDataAdapter.Dispose();
            Close();
            return itemNames;
        }

        public ShopItem GetItemByName(string name)
        {
            ObservableCollection<ShopItem> items = GetItems();
            foreach (ShopItem item in items)
            {
                if (item.Name == name)
                    return item;
            }
            return null;
        }

        public List<string> GetPickLinks()
        {
            Connect("StorageDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT PickLink FROM Storage", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<string> items = new List<string>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                items.Add(dr[0].ToString());
            }
            return items;
        }

        public void DeleteInDB(string name)
        {
            Connect("StorageDB");
            SqlCommand command = new(
                "DELETE FROM [Storage] WHERE Name = @Name"
                , _sqlConnection);
            command.Parameters.AddWithValue("Name", name);
            command.ExecuteNonQuery();
            Close();
        }

        public void DeleteInWorkspace(string name)
        {
            Connect("StorageDB");

            SqlDataAdapter sqlDataAdapter = new("SELECT PickLink FROM Storage WHERE Name = N'" + name + "'", _sqlConnection);
            DataSet ds = new();
            sqlDataAdapter.Fill(ds);
            ds.IsInitialized.ToString();
            List<string> itemNames = new();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                itemNames.Add(dr[0].ToString());
            }
            var x = Directory.GetCurrentDirectory() + itemNames[0];
            File.Delete(x);
            sqlDataAdapter.Dispose();
            Close();
        }
    }
}

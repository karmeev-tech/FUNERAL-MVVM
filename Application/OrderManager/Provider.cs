using Domain.Order;
using Domain.Services.Entity;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Storage;
using Infrastructure.Mongo;
using LegacyInfrastructure.Worker;
using System.Text.Json;
using System.Windows;

namespace OrderManager
{
    public class Provider
    {
        // metadata
        public static string _managerName = new WorkerRepos().GetLastFromJournal();
        public static string _dateNow = DateTime.Now.ToString();
        public static string _numberDb = string.Empty;
        public static void CreateOrder(string workspaceDocs, string workspaceJson, string programWorkspace)
        {
            Provider.Clean(workspaceDocs);
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет"))
            {
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет", true);
            }

            string json = "";
            using (StreamReader r = new StreamReader(workspaceJson + "\\OrderDoc.json"))
            {
                json = r.ReadToEnd();
            }

            string json2 = "";
            var compservPath = workspaceJson + "\\ComplectFuneralDoc.json";
            if (File.Exists(compservPath) == true)
            {
                using (StreamReader r = new StreamReader(workspaceJson + "\\ComplectFuneralDoc.json"))
                    json2 = r.ReadToEnd();
            }

            compservPath = workspaceJson + "\\ServicesDoc.json";
            string json3 = "";
            if (File.Exists(compservPath) == true)
            {
                using (StreamReader r = new StreamReader(workspaceJson + "\\ServicesDoc.json"))
                    json3 = r.ReadToEnd();
            }


            OrderEntity order = JsonSerializer.Deserialize<OrderEntity>(json);

            List<StorageItemEntity> complect = new();
            if (json2 != "")
            {
                complect = JsonSerializer.Deserialize<List<StorageItemEntity>>(json2);
            }

            List<Service> services = new();
            if (json3 != "")
            {
                services = JsonSerializer.Deserialize<List<Service>>(json3);
            }

            OrderCreator manager = new();
            var entity = new StateEntity()
            {
                Id = MongoFuneral.GetUniqueId(),
                ManagerName = new WorkerRepos().GetLastFromJournal(),
                Time = DateTime.Now.ToString(),
                Order = order,
                Complect = new ItemsEntity { Id = 0, Complect = complect },
                Services = new ComplexServiceEntity { Id = 0, Services = services },
            };
            MongoFuneral.ConnectAndAddFile(entity);
            Console.WriteLine("в монгу закинул");
            if (!Directory.Exists(@"\.workspace\docs"))
            {
                Directory.CreateDirectory(@"\.workspace\docs");
            }

            try
            {
                manager.CreateDoc(entity.Id.ToString(),
                order.ClientOrder.Name + " " + order.ClientOrder.LastName + " " + order.ClientOrder.ThirdName,
                order.ClientOrder.Passport,
                order.ClientOrder.Adress,
                GetServicesByName(services),
                GetServicesPrice(services, complect),
                order.Price,
                order.Prepayment,
                order.ClientOrder.Phone);

                manager.CreateFuneralDock(entity.Id.ToString(),
                    order.ClientOrder.Name + " " + order.ClientOrder.LastName + " " + order.ClientOrder.ThirdName,
                    order.ClientOrder.Passport,
                    order.ClientOrder.Adress,
                    GetComplectNames(complect),
                    order.Price,
                    order.Prepayment,
                    order.ClientOrder.Phone,
                    order.ClientOrder.Cemetry);

                var instal = "0";
                if (order.Instal.Idicate == "False")
                {
                    instal = order.Instal.InstalPrice;
                }

                manager.CreateBlank(
                    order.DeadassCount,
                    order.Deadass,
                    order.Base.Looks,
                    "Размер: " + order.Stela.Size + " Сечение: " + order.Stela.Section,
                    "Размер: " + order.Stand.Size + " Сечение: " + order.Stand.Section,
                    order.Flowershed.NoInstal == "False" ? "Размер: " + order.Flowershed.Size : "без цветника",
                    order.Funeral.Color,
                    order.Polishing,
                    "",
                    order.Funeral.UpPart,
                    order.Funeral.DownPart,
                    order.Funeral.Other,
                    order.Funeral.Epitafia,
                    order.ClientOrder.DateToday,
                    order.ClientOrder.DateCreation,
                    order.ClientOrder.Name + " " + order.ClientOrder.LastName + " " + order.ClientOrder.ThirdName,
                    order.ClientOrder.Adress,
                    order.ClientOrder.Phone,
                    order.ClientOrder.Cemetry,
                    order.ClientOrder.DeliveryPlace,
                    instal,
                    order.Price,
                    order.Prepayment,
                    order.Remainder,
                    order.Funeral.Type,
                    order.Base.ModelFuneral
                    );
            }
            catch (Exception)
            {
                MessageBox.Show("доки не генерятся");
                Console.WriteLine("доки не генерятся");
            }

            try
            {
                DocumentTransferring(workspaceDocs, programWorkspace);
            }
            catch (Exception)
            {
                MessageBox.Show("проблема с трансфером");
                Console.WriteLine("проблема с трансфером");
            }
        }
        private static string GetServicesByName(List<Service> services)
        {
            string result = string.Empty;
            foreach (Service service in services)
            {
                result += service.Name + ",\n";
            }
            return result;
        }
        private static string GetServicesPrice(List<Service> services, List<StorageItemEntity> complect)
        {
            int result = 0;
            foreach (Service service in services)
            {
                result += service.Money;
            }
            result += GetFunPrice(complect);
            return result.ToString();
        }
        private static int GetFunPrice(List<StorageItemEntity> complect)
        {
            int result = 0;
            foreach (StorageItemEntity service in complect)
            {
                result += service.Price;
            }
            return result;
        }
        private static string GetComplectNames(List<StorageItemEntity> items)
        {
            string result = string.Empty;
            foreach (StorageItemEntity item in items)
            {
                result += item.Name + " " + item.Price + " .руб" + " (" + item.Count + "), \n";
            }
            return result;
        }

        // TRANSFERRING
        private static void DocumentTransferring(string workspaceDocs, string programWorkspace)
        {
            var time = DateTime.Now.ToString();
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет");
            File.Copy(programWorkspace + @"\.workspace\docs\ReplacedDock.docx", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\doc1.docx");
            File.Copy(programWorkspace + @"\.workspace\docs\ReplacedFuneralDock.docx", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\doc2.docx");
            File.Copy(programWorkspace + @"\.workspace\docs\ReplacedFuneralBlank.docx", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\blank.docx");

            if (Directory.Exists(workspaceDocs))
            {
                var dir = workspaceDocs + "\\" + Provider._managerName + "" + time.Replace(" ", "").Replace(":", "") + "" + Provider._numberDb + @"\";
                Directory.CreateDirectory(dir);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\doc1.docx", dir + "doc1.docx", false);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\doc2.docx", dir + "doc2.docx", false);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\blank.docx", dir + "blank.docx", false);
            }
            else
            {
                Directory.CreateDirectory(workspaceDocs);
                var dir = workspaceDocs + "\\" + Provider._managerName + "" + time.Replace(" ", "").Replace(":", "") + "" + Provider._numberDb;
                Directory.CreateDirectory(dir);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\doc1.docx", dir + "\\doc1.docx", false);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\doc2.docx", dir + "\\doc2.docx", false);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\blank.docx", dir + "\\blank.docx", false);
            }
        }
        public static void Clean(string path)
        {
            var dir = path;

            if (DateTime.Now.Day == 1)
            {
                Directory.Delete(dir, true);
                Directory.CreateDirectory(dir);
            }
        }
    }
}

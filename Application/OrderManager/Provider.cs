using Domain.Order;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Services;
using Infrastructure.Model.Storage;
using Infrastructure.Mongo;
using System.Windows;
using Worker.EF;

namespace OrderManager
{
    public class Provider
    {
        // metadata
        public static string _managerName = "";
        public static string _dateNow = DateTime.Now.ToString();
        public static string _numberDb = string.Empty;
        public static void CreateOrder(string workspaceDocs, string workspaceJson, string programWorkspace)
        {
            Provider.Clean(workspaceDocs);
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет"))
            {
                try
                {
                    Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет", true);
                }
                catch
                {
                    MessageBox.Show("Закройте документ и заполните заказ заново");
                    return;
                }
            }

            OrderEntity order = MongoOrders.GetItems().First();
            MongoOrders.ConnectAndDeleteAllFiles();

            List<StorageItemEntity> complect = MongoComplect.GetItems();
            MongoComplect.ConnectAndDeleteAllFiles();

            List<ServiceEntity> services = MongoServices.GetItems();
            MongoServices.ConnectAndDeleteAllFiles();

            OrderCreator manager = new();
            string managerName = WorkerConnector.GetLastLoginWorker().Worker;
            var entity = new StateEntity()
            {
                Id = MongoFuneral.GetUniqueId(),
                ManagerName = managerName,
                Time = DateTime.Now.ToString(),
                Order = order,
                Complect = new ItemsEntity { Id = 0, Complect = complect },
                Services = new ComplexServiceEntity { Id = 0, Services = services },
            };

            MongoFuneral.ConnectAndAddFile(entity);
            if(complect.Any())
            {
                var shopName = WorkerConnector.GetWorkerShop(managerName);
                foreach(var item in complect)
                {
                    item.Id = MongoFuneral.GetUniqueId();
                    item.ShopName = shopName;
                    MongoItems.ConnectAndAddFile(item);
                }
            }
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
                order.FuneralPrice,
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
                    order.ClientOrder.Cemetry,
                    order.Base.CategoryFuneral);

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
                return;
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
        private static string GetServicesByName(List<ServiceEntity> services)
        {
            string result = string.Empty;
            foreach (ServiceEntity service in services)
            {
                result += service.Name + " (" + service.Param1 + ") " + ",\n";
            }
            return result;
        }
        private static string GetServicesPrice(List<ServiceEntity> services, List<StorageItemEntity> complect)
        {
            int result = 0;
            foreach (ServiceEntity service in services)
            {
                result += service.Money;
            }
            result += GetFunPrice(complect);
            return result.ToString();
        }
        private static int GetFunPrice(List<StorageItemEntity> complect)
        {
            int result = 0;
            foreach (StorageItemEntity complectItem in complect)
            {
                result += complectItem.Price * complectItem.Count;
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

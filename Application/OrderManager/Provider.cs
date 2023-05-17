using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Complect;
using Domain.Issue;
using Domain.Order;
using Domain.Services.Entity;
using LegacyInfrastructure.Worker;
using ORDCreator;
using System.Text.Json;

namespace OrderManager
{
    public class Provider
    {
        // metadata
        public static string _managerName = new WorkerRepos().GetLastFromJournal();
        public static string _dateNow = DateTime.Now.ToString();
        public static string _numberDb = string.Empty;
        public static void CreateOrder()
        {
            Provider.Clean();
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет"))
            {
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет", true);
            }

            string json = "";
            using (StreamReader r = new StreamReader(".docs\\json\\OrderDoc.json"))
            {
                json = r.ReadToEnd();
            }

            string json2 = "";
            using (StreamReader r = new StreamReader(".docs\\json\\ComplectFuneralDoc.json"))
            {
                json2 = r.ReadToEnd();
            }

            string json3 = "";
            using (StreamReader r = new StreamReader(".docs\\json\\ServicesDoc.json"))
            {
                json3 = r.ReadToEnd();
            }

            OrderEntity order =
            JsonSerializer.Deserialize<OrderEntity>(json);

            List<ItemComplectEntity> complect =
            JsonSerializer.Deserialize<List<ItemComplectEntity>>(json2);

            List<Service> services =
            JsonSerializer.Deserialize<List<Service>>(json3);

            OrderCreator manager = new();

            manager.CreateDoc("1",
                order.ClientOrder.Name,
                order.ClientOrder.Passport,
                order.ClientOrder.Adress,
                GetServicesByName(services),
                GetServicesPrice(services),
                order.Price,
                order.Prepayment,
                order.ClientOrder.Phone);

            manager.CreateFuneralDock("1",
                order.ClientOrder.Name,
                order.ClientOrder.Passport,
                order.ClientOrder.Adress,
                GetComplectNames(complect),
                order.Price,
                order.Prepayment,
                order.ClientOrder.Phone,
                order.ClientOrder.Cemetry);

            var instal = "0";
            if(order.Instal.Idicate == "False")
            {
                instal = order.Instal.InstalPrice;
            }

            manager.CreateBlank(
                order.DeadassCount,
                order.Deadass,
                order.Base.Looks,
                "Размер: " + order.Stela.Size + " Сечение: " + order.Stela.Section,
                "Размер: " + order.Stand.Size + " Сечение: " + order.Stand.Section,
                order.Flowershed.NoInstal == "False" ? "Размер: " + order.Flowershed.Size + " Сечение: " + order.Flowershed.Section : "без цветника",
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

            DocumentTransferring();
        }
        private static string GetServicesByName(List<Service> services)
        {
            string result = string.Empty;
            foreach (Service service in services)
            {
                result += service.Name + " (" + service.Param1 + ", " + service.Param2 + ")\n";
            }
            return result;
        }
        private static string GetServicesPrice(List<Service> services)
        {
            int result = 0;
            foreach (Service service in services)
            {
                result += service.Money;
            }
            return result.ToString();
        }
        private static string GetComplectNames(List<ItemComplectEntity> items)
        {
            string result = string.Empty;
            foreach(ItemComplectEntity item in items)
            {
                result += item.Name + " " + item.Money + " .руб" + " (" + item.Count + "), \n"; 
            }
            return result;
        }
        private static List<DeadEntity> DeadassPersons(string deadass)
        {
            List<DeadEntity> entities = new();
            var items = deadass.Split('\n').ToList();
            items.RemoveAt(items.Count-1);
            foreach (var item in items)
            {
                var person = item.Split(' ');
                entities.Add(new DeadEntity()
                {
                    DeadFIO = person[0],
                    DeadBirth = person[1],
                    DeadDie = person[2]
                });
            }
            return entities;
        }

        // TRANSFERRING
        public static void IssueTransferring(string path)
        {
            string json = "";
            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }

            BaseIssueEntity issue = JsonSerializer.Deserialize<BaseIssueEntity>(json);

            string[] transfer = new[]
            {
                @".workspace\issue\send\Transfer\completefiles\doc1.docx",
                @".workspace\issue\send\Transfer\completefiles\doc2.docx",
                @".workspace\issue\send\Transfer\completefiles\doc3.docx",
                @".workspace\issue\send\Transfer\basefiles\generatedoc1.docx",
                @".workspace\issue\send\Transfer\basefiles\generatedoc2.docx",
                @".workspace\issue\send\Transfer\basefiles\generatedoc3.docx",
                @".workspace\issue\send\Transfer\meta\meta.ord"
            };

            Directory.CreateDirectory(@".workspace\issue\send\Transfer\basefiles");
            Directory.CreateDirectory(@".workspace\issue\send\Transfer\completefiles");
            Directory.CreateDirectory(@".workspace\issue\send\Transfer\meta");

            File.Copy(issue.DockPath, transfer[0]);
            File.Copy(issue.Dock2Path, transfer[1]);
            File.Copy(issue.ScanPath, transfer[2]);

            File.Copy(Directory.GetCurrentDirectory() + @"\.workspace\docs\ReplacedDock.docx", transfer[3]);
            File.Copy(Directory.GetCurrentDirectory() + @"\.docs\CreateFuneralDock.docx", transfer[4]);
            File.Copy(Directory.GetCurrentDirectory() + @"\.workspace\docs\ReplacedFuneralBlank.docx", transfer[5]);

            File.Copy(issue.OrdPath, transfer[6]);

            XordTransfer xordTransfer = new();
            xordTransfer.CreateTransfer(@".workspace\issue\send\Transfer", @".workspace\issue\send");
        }
        public static void GeneralIssueTransferring()
        {
            DordTransfer dordTransfer = new DordTransfer();
            dordTransfer.CreateTransfer(@".workspace\issue\send");
        }
        private static void DocumentTransferring()
        {
            var time = DateTime.Now.ToString(); 
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет");
            File.Copy(Directory.GetCurrentDirectory() + @"\.workspace\docs\ReplacedDock.docx", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\Документ1.docx");
            File.Copy(Directory.GetCurrentDirectory() + @"\.docs\CreateFuneralDock.docx", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\Документ2.docx");
            File.Copy(Directory.GetCurrentDirectory() + @"\.workspace\docs\ReplacedFuneralBlank.docx", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\Бланк.docx");

            if (Directory.Exists("C:\\ProgramData\\KarmeevTech\\Funeral"))
            {
                var dir = "C:\\ProgramData\\KarmeevTech\\Funeral\\docs" + Provider._managerName + "-" + time.Replace(" ", "-").Replace(":", "-") + " " + Provider._numberDb + @"\" ;
                Directory.CreateDirectory(dir);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\Документ1.docx", dir + "Документ1.docx", false);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\Документ2.docx", dir + "Документ2.docx",false);
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\Бланк.docx", dir + "Бланк.docx", false);
            }
            else
            {
                Directory.CreateDirectory("C:\\ProgramData\\KarmeevTech\\Funeral");
                var dir = "C:\\ProgramData\\KarmeevTech\\Funeral\\docs" + Provider._managerName + "-" + Provider._dateNow + "-" + Provider._numberDb;
                Directory.CreateDirectory(dir);
            }

            OrdTransfer transfer = new();
            transfer.CreateTransfer();
        }

        public static void Clean()
        {
            var dir = @"C:\ProgramData\KarmeevTech\Funeral\";

            if (DateTime.Now.Day == 1)
            {
                Directory.Delete(dir, true);
                Directory.CreateDirectory(dir);
            }
        }
    }
}

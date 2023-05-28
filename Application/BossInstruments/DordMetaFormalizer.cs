using Domain.Dord;
using Domain.GeneralOrder;
using Infrastructure.Context.Salary;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Salary;
using Infrastructure.Model.Storage;
using Infrastructure.Mongo;
using ORDCreator;
using Shop.EF;
using System.Configuration;
using System.Text.Json;
using System.Windows;
using Worker.EF;

namespace BossInstruments
{
    public class DordMetaFormalizer
    {
        public static DordMeta GetJson(string pathsToJson)
        {
            string json = "";
            using (StreamReader r = new StreamReader(pathsToJson))
            {
                json = r.ReadToEnd();
            }

            return JsonSerializer.Deserialize<DordMeta>(json);
        }

        public static void SendDord(string funeralFolder)
        {
            var desktopDir = ConfigurationManager.AppSettings["ProgramDord"] + @"\dord";
            if (Directory.Exists(desktopDir))
            {
                Directory.Delete(desktopDir, true);
            }

            var jsonFolder = desktopDir + @"\orderjson";
            Directory.CreateDirectory(jsonFolder);

            var docsFolder = desktopDir + @"\Documents";
            Directory.CreateDirectory(docsFolder);

            Console.WriteLine(funeralFolder);

            if (!Directory.Exists(funeralFolder))
            {
                return;
            }

            try
            {
                if (Directory.Exists(ConfigurationManager.AppSettings["ScanDocs"]))
                {
                    Directory.Move(ConfigurationManager.AppSettings["ScanDocs"], docsFolder + @"\scan");
                }
                if (Directory.Exists(ConfigurationManager.AppSettings["GenerateDocs"]))
                {
                    Directory.Move(ConfigurationManager.AppSettings["GenerateDocs"], docsFolder + @"\gen");
                }

                Directory.CreateDirectory(ConfigurationManager.AppSettings["GenerateDocs"]);
                Directory.CreateDirectory(ConfigurationManager.AppSettings["ScanDocs"]);

                DordusEntity stateEntity = new DordusEntity()
                {
                    Time = WorkerConnector.GetStartToDayTime(),
                    TimeEnd = DateTime.Now.ToString(),
                    ManagerName = WorkerConnector.GetLastLoginWorker().Worker,
                    AllOrders = MongoFuneral.GetItems().Select(x => x.Order).ToList(),
                    Complect = new ItemsEntity()
                    {
                        Id = 0,
                        Complect = MongoItems.GetItems()
                    },
                    AllServices = MongoFuneral.GetItems().Select(x => x.Services).ToList(),
                };

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(stateEntity, options);
                File.WriteAllText(jsonFolder + @"\forder.json", json);

                Zipper.CreateDordFile(
                    desktopDir,
                    "dord",
                    ConfigurationManager.AppSettings["ProgramDord"] + @"\dord.zip");
                //Directory.Delete(ConfigurationManager.AppSettings["ProgramDord"] + @"\dord.zip");

                MongoItems.ConnectAndDeleteAllFiles();
                MongoFuneral.ConnectAndDeleteAllFiles();
                MessageBox.Show("Отчёт кассира сформирован");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Услуги не были оказаны");
            }
        }

        public static void UpdateWithDord(List<DordEntity> dordEntities,
                                          List<StorageItemEntity> storageItemEntities,
                                          // List<OrderDord> orderDords, //нахуй не нужна
                                          List<SalaryEntity> salaryEntities //нахуй не нужна на самом то деле тоже
                                          )
        {
            var money = salaryEntities.Where(x => x.WorkerName == dordEntities.First().ManagerName).Select(x => x.WorkerMoney).First();
            UpdateSalary(dordEntities.First().ManagerName,
                Convert.ToInt32(dordEntities.First().Salary),
                money);

            ShopConnector.EditItemInShop(storageItemEntities);

        }

        public static void UpdateSalary(string workerName, int money, int realMoney)
        {
            using (var db = new SalaryContext())
            {
                var query = from b in db.IssueMoney
                            where b.WorkerName == workerName
                            select b;
                if (!query.Any())
                {
                    return;
                }
                int id = query.First().Id;
                SalaryEntity updateSalary = query.First();
                db.IssueMoney.Remove(query.First());
                db.SaveChanges();

                if (updateSalary.WorkerMoney != realMoney)
                {
                    updateSalary.WorkerMoney = realMoney;
                }
                updateSalary.WorkerMoney += money;
                db.IssueMoney.Add(updateSalary);
                db.SaveChanges();
            }
        }
    }
}

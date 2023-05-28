using BossInstruments;
using ClassLibrary;
using Domain.Dord;
using Domain.Order;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Storage;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace FUNERALMVVM.Commands.Dord
{
    public class GetDordCommand : BaseCommands
    {
        private readonly DORDController _dORDController;

        public GetDordCommand(DORDController dORDController)
        {
            _dORDController = dORDController;
        }

        public override void Execute(object parameter)
        {

            if (Directory.Exists(ConfigurationManager.AppSettings["ProgramWorkspaceDord"]))
            {
                Directory.Delete(ConfigurationManager.AppSettings["ProgramWorkspaceDord"], true);
                Directory.CreateDirectory(ConfigurationManager.AppSettings["ProgramWorkspaceDord"]);
            }

            var pickManager = new PickManager();

            var bossFolder = _dORDController.LinkToFolder;
            var dordFile = pickManager.OpenManagerFileNameDord();

            if (dordFile == string.Empty)
            {
                _dORDController.LinkToFolder = "Укажите ссылку на dord файл";
                return;
            }
            try
            {
                FinalOrderManager.GetDord(bossFolder, dordFile);
                var programWorkspace = ConfigurationManager.AppSettings["ProgramWorkspaceDord"];
                string json = File.ReadAllText(programWorkspace + @"\orderjson\forder.json");
                DordusEntity finalochka = JsonSerializer.Deserialize<DordusEntity>(json);

                List<StorageItemEntity> items = finalochka.Complect.Complect;
                List<OrderEntity> orders = finalochka.AllOrders;
                List<ComplexServiceEntity> servs = finalochka.AllServices;
                foreach (OrderEntity item in orders)
                {
                    OrderDord orderDord = new OrderDord()
                    {
                        CategoryFuneral = item.Base.CategoryFuneral,
                        ModelFuneral = item.Base.ModelFuneral,
                        Rock = item.Base.Rock,
                        Price = item.Price,
                        Prepayment = item.Prepayment,
                        Remainder = item.Remainder,
                    };
                    _dORDController.Order.Add(orderDord);
                }
                _dORDController.Items = new(items);

                var orderMoney = _dORDController.Order.Select(x => x.Price);

                foreach (var item in _dORDController.Items)
                {
                    item.ZakupPrice += item.Price * item.Count;
                }



                //Read the JSON file into a string
                string jsonString = File.ReadAllText(ConfigurationManager.AppSettings["Settings"] + "\\WorkerSettings.json");

                // Deserialize the JSON string to a C# object
                WorkerConfig workerConfig = JsonSerializer.Deserialize<WorkerConfig>(jsonString);

                int itemsMoney = 0;

                foreach (var item in _dORDController.Items)
                {
                    itemsMoney += item.Price / 100 * item.Procent * item.Count;
                }

                foreach (var item in orderMoney)
                {
                    workerConfig.HisMoney += Convert.ToInt32(item);
                    workerConfig.MoneyGet += Convert.ToInt32(item);
                }
                workerConfig.HisMoney += itemsMoney;

                var zakupPrice = _dORDController.Items.Select(x => x.ZakupPrice);
                foreach(var item in zakupPrice)
                {
                    workerConfig.MoneyGet += item;
                }

                //оклад на зп
                workerConfig.HisMoney += Convert.ToInt32(workerConfig.Oklad);

                _dORDController.WorkerEntities.Add(new DordEntity()
                {
                    ManagerName = finalochka.ManagerName,
                    StartWorkTime = finalochka.Time,
                    EndWorkTime = finalochka.TimeEnd,
                    Money = workerConfig.MoneyGet.ToString(),
                    Oklad = workerConfig.Oklad,
                    Salary = workerConfig.HisMoney.ToString(),
                });
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

        }
    }

    public class WorkerConfig
    {
        public int FuneralProcent { get; set; }
        public string Oklad { get; set; }

        public int MoneyGet { get; set; }
        public int HisMoney { get; set; }
    }
}
